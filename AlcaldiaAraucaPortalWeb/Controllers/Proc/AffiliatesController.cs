using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Helper;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment _env;
        private readonly IGroupCommunityHelper _communityHelper;
        private readonly IProfessionHelper _professionHelper;
        private readonly ISocialNetworkHelper _socialNetworkHelper;
        private readonly IAffiliateGroupProductiveHelper _groupProductiveHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConfiguration _configuration;

        public AffiliatesController(
            IAffiliateHelper affiliate, IUserHelper userHelper,
            IGroupProductiveHelper productiveHelper,
            IWebHostEnvironment env,
            IGroupCommunityHelper communityHelper,
            IProfessionHelper professionHelper,
            ISocialNetworkHelper socialNetworkHelper,
            IAffiliateGroupProductiveHelper groupProductiveHelper,
            IImageHelper imageHelper,
            IConfiguration configuration)
        {
            _affiliate = affiliate;
            _userHelper = userHelper;
            _productiveHelper = productiveHelper;
            _env = env;
            _communityHelper = communityHelper;
            _professionHelper = professionHelper;
            _socialNetworkHelper = socialNetworkHelper;
            _groupProductiveHelper = groupProductiveHelper;
            _imageHelper = imageHelper;
            this._configuration = configuration;
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
                //Guardar la imagen
                var path = string.Empty;

                if (model.ImagePath != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImagePath, "Image\\Afiliate\\Image");
                }

                if(model.Professions.Count>0)
                {
                    for (int i = 0; i < model.Professions.Count; i++)
                    {
                        var pathProfession = FileMove(model.Professions[i].DocumentoPath, "Image\\Afiliate\\Document");
                        model.Professions[i].DocumentoPath = pathProfession;
                        var pathImage = FileMove(model.Professions[i].ImagePath, "Image\\Afiliate\\Image");
                        model.Professions[i].ImagePath = pathImage;
                    }
                }

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
                    ImagePath = path,
                    GroupProductives = model.Productivo.Select(p => new AffiliateGroupProductive() { GroupProductiveId = p.GroupProductiveId }).ToList(),
                    GroupCommunities = model.Comuntario.Select(c => new AffiliateGroupCommunity() { GroupCommunityId = c.GroupCommunityId }).ToList(),
                    Professions = model.Professions.Select(p => new AffiliateProfession() { ProfessionId = p.ProfessionId, Concept = p.Concept, ImagePath = p.ImagePath, DocumentoPath = p.DocumentoPath }).ToList(),
                    SocialNetworks = model.SocialNetwork.Select(s => new AffiliateSocialNetwork() { SocialNetworkId = s.SocialNetworkId, AffiliateSocialNetworURL = s.SocialNetworURL }).ToList()
                };

                var response = await _affiliate.AddUpdateAsync(afiliate);

                if (response.Succeeded)
                {
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
            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ByIdAffiliateAsync(model.AffiliateId), "GroupCommunityId", "GroupCommunityName");
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ByIdAffiliateAsync(model.AffiliateId), "ProfessionId", "ProfessionName");
            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ByIdAffiliateAsync(model.AffiliateId), "SocialNetworkId", "SocialNetworkName");
            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName", model.TypeUserId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Affiliate model)
        {
            if (id != model.AffiliateId)
            {
                return NotFound();
            }
            //TODO: Falta agregar guardar
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este registro");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            
            return View();
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
        public async Task<JsonResult> getProfession(string GroupProfession)
        {
            if (GroupProfession == null)
            {
                var model = await _professionHelper.ComboAsync();

                return Json(model);
            }
            else
            {
                GroupProfession = GroupProfession.Substring(0, GroupProfession.Length - 1);

                string[] groupProfessionId = GroupProfession.Split(',').Select(d => d.ToString()).ToArray();

                var model = await _professionHelper.ComboAsync(groupProfessionId);

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

        private string DeleteImage(string file, string folder)
        {
            int start = file.LastIndexOf("/") + 1;

            var file2 = file.Substring(start, file.Length - start);

            file2 = Path.Combine(_env.WebRootPath, folder, file2);

            FileInfo fi = new FileInfo(file2);

            if (fi != null)
            {
                System.IO.File.Delete(file2);
                fi.Delete();
            }

            return "Ok";
        }

        [HttpPost]
        public async Task<IActionResult> UploadeTemp(IFormFile fileImg, IFormFile fileDoc)
        {
            var path = _configuration["MyFolders:AfiliateTemp"];

            var responseImg = await _imageHelper.UploadImageAsync(fileImg, path);
            
            var responseDoc = await _imageHelper.UploadFileAsync(fileDoc, path);            

            return Json(new { pathImg = responseImg, pathDoc = responseDoc });
        }

        [HttpPost]
        public IActionResult DeleteTemp(string fileImg,string filePdf)
        {
            var path = _configuration["MyFolders:AfiliateTemp"];

            int startImg = fileImg.LastIndexOf("/") + 1;

            var fileImg2 = fileImg.Substring(startImg, fileImg.Length - startImg);

            fileImg2 = Path.Combine(_env.WebRootPath, path, fileImg2);

            FileInfo fi = new FileInfo(fileImg2);
            if (fi != null)
            {
                System.IO.File.Delete(fileImg2);
                fi.Delete();
            }


            int startPdf = filePdf.LastIndexOf("/") + 1;

            var filePdf2 = filePdf.Substring(startPdf, filePdf.Length - startPdf);

            filePdf2 = Path.Combine(_env.WebRootPath, path, filePdf2);


            FileInfo fiPdf = new FileInfo(filePdf2);
            if (fiPdf != null)
            {
                System.IO.File.Delete(filePdf2);
                fiPdf.Delete();
            }

            return Json(new { path = "Ok" });
        }

        private string FileMove(string sourceFileName, string destFileName)
        {
            var Folder = destFileName.Replace("\\", "/");

            var pathFolder = _configuration["MyFolders:AfiliateTemp"];

            var url = _configuration["MyDomain:Url"];

            int star = sourceFileName.LastIndexOf("/") + 1;

            var file = sourceFileName.Substring(star, sourceFileName.Length - star);

            sourceFileName = Path.Combine(_env.WebRootPath, pathFolder, file);

            destFileName = destFileName.Replace('/', '\\');

            destFileName = Path.Combine(_env.WebRootPath, destFileName, file);

            System.IO.File.Move(sourceFileName, destFileName);

            return $"{url}{Folder}/{file}";
        }

        //[HttpGet]
        //public IActionResult GetCustomerById(int id)
        //{
        //    var resul = "https://localhost:44334/";

        //    return Json(resul);
        //}
    }
}
