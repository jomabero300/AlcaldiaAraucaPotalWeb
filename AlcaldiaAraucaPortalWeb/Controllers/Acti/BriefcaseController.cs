using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Acti
{
    public class BriefcaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BriefcaseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Data.Entities.Acti.Briefcase obj;
            List<Data.Entities.Acti.Briefcase> Objs = new List<Data.Entities.Acti.Briefcase>();
            obj = new Data.Entities.Acti.Briefcase()
            {
                BriefcaseId=1,
                BriefcaseImage= "https://www.pngitem.com/pimgs/m/10-105134_imagenes-en-formato-png-gratis-transparent-png.png",
                BriefcaseTitel ="TELSOF",
                BriefcaseText="desarrollador de software y telecomunicaciones",
                BriefcaseDescrption= "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
                BriefcaseUrl= "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseFacebook= "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseGoogle = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseSkype = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseTwitter = "https://bootstrap-menu.com/demos/basic-hover-js.html"
            };

            Objs.Add(obj);

            obj = new Data.Entities.Acti.Briefcase()
            {
                BriefcaseId = 1,
                BriefcaseImage = "https://www.pngitem.com/pimgs/m/10-105134_imagenes-en-formato-png-gratis-transparent-png.png",
                BriefcaseTitel = "TELSOF",
                BriefcaseText = "desarrollador de software y telecomunicaciones",
                BriefcaseDescrption = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
                BriefcaseUrl = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseFacebook = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseGoogle = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseSkype = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseTwitter = "https://bootstrap-menu.com/demos/basic-hover-js.html"
            };

            Objs.Add(obj);
            obj = new Data.Entities.Acti.Briefcase()
            {
                BriefcaseId = 1,
                BriefcaseImage = "https://www.pngitem.com/pimgs/m/10-105134_imagenes-en-formato-png-gratis-transparent-png.png",
                BriefcaseTitel = "TELSOF",
                BriefcaseText = "desarrollador de software y telecomunicaciones",
                BriefcaseDescrption = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
                BriefcaseUrl = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseFacebook = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseGoogle = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseSkype = "https://bootstrap-menu.com/demos/basic-hover-js.html",
                BriefcaseTwitter = "https://bootstrap-menu.com/demos/basic-hover-js.html"
            };

            Objs.Add(obj);

            return View(Objs);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BriefcaseId,BriefcaseTitel,BriefcaseImage,BriefcaseText,BriefcaseUrl,BriefcaseDescrption,BriefcaseFacebook,BriefcaseTwitter,BriefcaseSkype,BriefcaseGoogle")] Briefcase model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
