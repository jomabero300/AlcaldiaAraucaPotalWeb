using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Acti
{
    public class BriefcaseController : Controller
    {
        private readonly IBriefcaseHelper _briefcaseHelper;
        private readonly ISocialNetworkHelper _socialNetwork;
        private readonly IBriefcaseSocialNetworkHelper _socialNetworkHelper;

        public BriefcaseController(IBriefcaseHelper briefcaseHelper, ISocialNetworkHelper socialNetwork, IBriefcaseSocialNetworkHelper socialNetworkHelper)
        {
            _briefcaseHelper = briefcaseHelper;
            _socialNetwork = socialNetwork;
            _socialNetworkHelper = socialNetworkHelper;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _briefcaseHelper.ListAsync();
            return View(model);
        }
        //public IActionResult Index()
        //{
        //    Briefcase obj;
        //    List<Briefcase> Objs = new List<Briefcase>();

        //    var socialNetwork = new List<SocialNetwork>();

        //    socialNetwork.Add(new SocialNetwork { SocialNetworkId = 1, SocialNetworkName = "Fecebook", StateId = 1 });
        //    socialNetwork.Add(new SocialNetwork { SocialNetworkId = 2, SocialNetworkName = "Google", StateId = 1 });
        //    socialNetwork.Add(new SocialNetwork { SocialNetworkId = 3, SocialNetworkName = "Skype", StateId = 1 });
        //    socialNetwork.Add(new SocialNetwork { SocialNetworkId = 4, SocialNetworkName = "Teitter", StateId = 1 });

        //    var redes = new List<BriefcaseSocialNetwork>();

        //    redes.Add(new BriefcaseSocialNetwork { BriefcaseSocialNetworkId = 1, BriefcaseId = 1, SocialNetworkId = 1, URL = "https://bootstrap-menu.com/demos/basic-hover-js.html" });
        //    redes.Add(new BriefcaseSocialNetwork { BriefcaseSocialNetworkId = 2, BriefcaseId = 1, SocialNetworkId = 2, URL = "https://bootstrap-menu.com/demos/basic-hover-js.html" });
        //    redes.Add(new BriefcaseSocialNetwork { BriefcaseSocialNetworkId = 3, BriefcaseId = 1, SocialNetworkId = 3, URL = "https://bootstrap-menu.com/demos/basic-hover-js.html" });
        //    redes.Add(new BriefcaseSocialNetwork { BriefcaseSocialNetworkId = 4, BriefcaseId = 1, SocialNetworkId = 4, URL = "https://bootstrap-menu.com/demos/basic-hover-js.html" });

        //    obj = new Briefcase()
        //    {
        //        BriefcaseId = 1,
        //        BriefcaseImage = "https://www.pngitem.com/pimgs/m/10-105134_imagenes-en-formato-png-gratis-transparent-png.png",
        //        BriefcaseTitel = "TELSOF",
        //        BriefcaseText = "desarrollador de software y telecomunicaciones",
        //        BriefcaseDescrption = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
        //        BriefcaseUrl = "https://bootstrap-menu.com/demos/basic-hover-js.html",
        //        BriefcaseSocialNetworks = redes.ToList()
        //    };

        //    Objs.Add(obj);

        //    obj = new Data.Entities.Acti.Briefcase()
        //    {
        //        BriefcaseId = 1,
        //        BriefcaseImage = "https://www.pngitem.com/pimgs/m/10-105134_imagenes-en-formato-png-gratis-transparent-png.png",
        //        BriefcaseTitel = "TELSOF",
        //        BriefcaseText = "desarrollador de software y telecomunicaciones",
        //        BriefcaseDescrption = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
        //        BriefcaseUrl = "https://bootstrap-menu.com/demos/basic-hover-js.html",
        //        BriefcaseSocialNetworks = redes.ToList()
        //    };

        //    Objs.Add(obj);
        //    obj = new Data.Entities.Acti.Briefcase()
        //    {
        //        BriefcaseId = 1,
        //        BriefcaseImage = "https://www.pngitem.com/pimgs/m/10-105134_imagenes-en-formato-png-gratis-transparent-png.png",
        //        BriefcaseTitel = "TELSOF",
        //        BriefcaseText = "desarrollador de software y telecomunicaciones",
        //        BriefcaseDescrption = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
        //        BriefcaseUrl = "https://bootstrap-menu.com/demos/basic-hover-js.html",
        //        BriefcaseSocialNetworks = redes.ToList()
        //    };

        //    Objs.Add(obj);

        //    return View(Objs);
        //}

        // GET: Genders/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SocialNetworkId"] = new SelectList(await _socialNetwork.ComboAsync(), "SocialNetworkId", "SocialNetworkName");

            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BriefcaseViewModelsActi model)
        {
            if (ModelState.IsValid)
            {
                var modelNetwork = model.BriefcaseSocialNetworks.Select(r => new BriefcaseSocialNetwork()
                {
                    SocialNetworkId = r.SocialNetworkId,
                    URL = r.URL
                });

                var modl = new Briefcase()
                {
                    BriefcaseDescrption = model.BriefcaseDescrption,
                    BriefcaseImage = model.BriefcaseImage,
                    BriefcaseText = model.BriefcaseText,
                    BriefcaseTitel = model.BriefcaseTitel,
                    BriefcaseUrl = model.BriefcaseUrl,
                    BriefcaseSocialNetworks = modelNetwork.ToList()
                };

                var responde = await _briefcaseHelper.AddUpdateAsync(modl);

                if (responde.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, responde.Message);
            }

            ViewData["SocialNetworkId"] = new SelectList(await _socialNetwork.ComboAsync(), "SocialNetworkId", "SocialNetworkName");

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> getSocialNetwork(string SocialNetwork)
        {
            if (SocialNetwork == null)
            {
                var model = await _socialNetwork.ComboAsync();

                return Json(model);
            }
            else
            {
                SocialNetwork = SocialNetwork.Substring(0, SocialNetwork.Length - 1);

                string[] groupProductiveId = SocialNetwork.Split(',').Select(d => d.ToString()).ToArray();

                var model = await _socialNetwork.ComboAsync(groupProductiveId);

                return Json(model);
            }
        }
    }
}
