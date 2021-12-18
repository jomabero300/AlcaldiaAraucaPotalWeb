using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Helper;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Proc
{
    [Authorize(Roles = "Usuario")]
    public class AffiliatesController : Controller
    {
        private readonly IAffiliateHelper _affiliate;
        private readonly IUserHelper _userHelper;
        private readonly IGroupProductiveHelper _productiveHelper;
        private readonly IWebHostEnvironment _webHost;
        private readonly IGroupCommunityHelper _communityHelper;
        private readonly IProfessionHelper _professionHelper;
        private readonly ISocialNetworkHelper _socialNetworkHelper;
        private readonly IAffiliateGroupProductiveHelper _groupProductiveHelper;

        public AffiliatesController(
            IAffiliateHelper affiliate, IUserHelper userHelper,
            IGroupProductiveHelper productiveHelper,
            IWebHostEnvironment webHost,
            IGroupCommunityHelper communityHelper,
            IProfessionHelper professionHelper,
            ISocialNetworkHelper socialNetworkHelper,
            IAffiliateGroupProductiveHelper groupProductiveHelper)
        {
            _affiliate = affiliate;
            _userHelper = userHelper;
            _productiveHelper = productiveHelper;
            _webHost = webHost;
            _communityHelper = communityHelper;
            _professionHelper = professionHelper;
            _socialNetworkHelper = socialNetworkHelper;
            _groupProductiveHelper = groupProductiveHelper;
        }

        // GET: Affiliates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _affiliate.AffiliateListAsync();
            //var applicationDbContext = _context.Affiliates.Include(a => a.ApplicationUser);
            return View(applicationDbContext);
        }

        // GET: Affiliates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var affiliate = await _context.Affiliates
            //    .Include(a => a.ApplicationUser)
            //    .FirstOrDefaultAsync(m => m.AffiliateId == id);
            var affiliate = await _affiliate.AffiliateByIdAsync((int)id);

            if (affiliate == null)
            {
                return NotFound();
            }

            return View(affiliate);
        }
        private List<TypeUserModelsView> typeUser()
        {
            List<TypeUserModelsView> typeUser = new List<TypeUserModelsView>();
            typeUser.Add(new TypeUserModelsView() { TypeUserId = "P", TypeUserName = "Persona" });
            typeUser.Add(new TypeUserModelsView() { TypeUserId = "E", TypeUserName = "Empresa" });
            typeUser.Add(new TypeUserModelsView() { TypeUserId = "", TypeUserName = "[Selecciones Tipo...]" });

            return typeUser.OrderBy(t => t.TypeUserName).ToList();

        }
        // GET: Affiliates/Create
        public async Task<IActionResult> Create()
        {
            ViewData["GroupProductiveId"] = new SelectList(await _productiveHelper.ComboAsync(), "GroupProductiveId", "GroupProductiveName");
            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ComboAsync(), "GroupCommunityId", "GroupCommunityName");
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboAsync(), "ProfessionId", "ProfessionName");
            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ComboAsync(), "SocialNetworkId", "SocialNetworkName");
            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName");

            return View();
        }

        // POST: Affiliates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AffiliateViewModelsProc model)
        {

            if (ModelState.IsValid)
            {
                var userId = _userHelper.UserByIdEmailAsync(User.Identity.Name);

                var afiliate = new Affiliate()
                {
                    UserId = userId.Id.ToString(),
                    TypeUserId = model.TypeUserId,
                    Name = model.Name,
                    Nit = model.Nit,
                    Address = model.Address,
                    Phone = model.Phone,
                    CellPhone = model.CellPhone,
                    Email = model.Email,
                    ImagePath = "",
                    GroupProductives = model.Productivo.Select(p => new AffiliateGroupProductive() { GroupProductiveId = p.GroupProductiveId }).ToList(),
                    GroupCommunities = model.Comuntario.Select(c => new AffiliateGroupCommunity() { GroupCommunityId = c.GroupCommunityId }).ToList(),
                    Professions = model.Professions.Select(p => new AffiliateProfession() { ProfessionId = p.ProfessionId, Concept = p.Concept, ImagePath = "", DocumentoPath = "" }).ToList(),
                    SocialNetworks = model.SocialNetwork.Select(s => new AffiliateSocialNetwork() { SocialNetworkId = s.SocialNetworkId, AffiliateSocialNetworURL = s.SocialNetworURL }).ToList()
                };

                var response = await _affiliate.AddUpdateAsync(afiliate);

                if (response.Succeeded)
                {
                    //guardar imagen principal
                    var ltRoute = $"1009-{afiliate.AffiliateId}.png";

                    var ltRouteName = FilesHelper.GetUploadedFileName(model.ImagePath, "Files\\Affiliate", ltRoute, _webHost);

                    afiliate.ImagePath = ltRouteName;

                    _affiliate.AddUpdateAsync(afiliate).Wait();

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            ViewData["GroupProductiveId"] = new SelectList(await _productiveHelper.ComboAsync(), "GroupProductiveId", "GroupProductiveName");

            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ComboAsync(), "GroupCommunityId", "GroupCommunityName");

            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboAsync(), "ProfessionId", "ProfessionName");

            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ComboAsync(), "SocialNetworkId", "SocialNetworkName");

            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName", model.TypeUserId);

            return View(model);
        }

        // GET: Affiliates/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _affiliate.AffiliateByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            ViewData["GroupProductiveId"] = new SelectList(await _productiveHelper.ByIdAffiliateAsync(model.AffiliateId), "GroupProductiveId", "GroupProductiveName");

            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ComboAsync(), "GroupCommunityId", "GroupCommunityName");
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboAsync(), "ProfessionId", "ProfessionName");
            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ComboAsync(), "SocialNetworkId", "SocialNetworkName");
            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName", model.TypeUserId);

            return View(model);
        }
           
        [HttpPost]
        public async Task<JsonResult> getProductive(string GroupProductive)
        {
            if (GroupProductive == null)
            {
                var mpio = await _productiveHelper.ComboAsync();

                return Json(mpio);
            }
            else
            {
                GroupProductive = GroupProductive.Substring(0, GroupProductive.Length - 1);

                string[] groupProductiveId = GroupProductive.Split(',').Select(d => d.ToString()).ToArray();

                var mpio = await _productiveHelper.ComboAsync(groupProductiveId);

                return Json(mpio);
            }
        }

        [HttpPost]
        public async Task<JsonResult> getCommunity(string GroupCommunity)
        {
            if (GroupCommunity == null)
            {
                var model = await _communityHelper.ComboAsync();

                return Json(model);
            }
            else
            {
                GroupCommunity = GroupCommunity.Substring(0, GroupCommunity.Length - 1);

                string[] groupProductiveId = GroupCommunity.Split(',').Select(d => d.ToString()).ToArray();

                var model = await _communityHelper.ComboAsync(groupProductiveId);

                return Json(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> getSocialNetwork(string SocialNetwork)
        {
            if (SocialNetwork == null)
            {
                var model = await _socialNetworkHelper.ComboAsync();

                return Json(model);
            }
            else
            {
                SocialNetwork = SocialNetwork.Substring(0, SocialNetwork.Length - 1);

                string[] groupProductiveId = SocialNetwork.Split(',').Select(d => d.ToString()).ToArray();

                var model = await _socialNetworkHelper.ComboAsync(groupProductiveId);

                return Json(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductiveAdd(int id,int GroupProductiveId)
        {
            var model = new AffiliateGroupProductive()
            {
                AffiliateId = id,
                GroupProductiveId = GroupProductiveId
            };

            var response = await _groupProductiveHelper.AddUpdateAsync(model);

            return RedirectToAction("Edit", new { id = model.AffiliateId});
        }

        [HttpPost]
        public async Task<IActionResult> ProductiveDelete(int AfiliateId, int GroupProductiveId)
        {
            var response = await _groupProductiveHelper.DeleteAsync(GroupProductiveId);

            return RedirectToAction("Edit", new { id = AfiliateId });
        }

        //[HttpGet]
        //public async Task<IActionResult> ProductiveDelete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    //buscar el Grupo productivo
        //    var model = await _groupProductiveHelper.ByIdGruopProductiveAsync((int)id);

        //    return View(model);
        //}

        //// POST: Genders/Delete/5
        //[HttpPost, ActionName("ProductiveDelete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ProductiveDeleteConfirmed(int id)
        //{
        //    //buscar el Grupo productivo
        //    var modelEdit = await _groupProductiveHelper.ByIdGruopProductiveAsync(id);
        //    var model = await _groupProductiveHelper.DeleteAsync(id);

        //    return RedirectToAction("Edit",new { id=modelEdit.AffiliateId});
        //}
    }
}
