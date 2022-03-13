using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class CarouselsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IImageHelper _imageHelper;
        private const string _searchFile= "Imagen0*";

        public CarouselsController(IWebHostEnvironment env, IImageHelper imageHelper)
        {
            _env = env;
            _imageHelper = imageHelper;
        }
        public IActionResult Index()
        {
            List<CarouselModelView> model = Helper.FilesHelper.ImageDirectory("Image", _env.WebRootPath,_searchFile);

            return View(model);
        }
        // GET: Genders/Create
        //TODO:Viy aqui
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarouselImage model)
        {
            if (ModelState.IsValid)
            {
                string response=await _imageHelper.UploadImageMenulAsync(model.Image, "Image");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Genders/Delete/5
        public IActionResult Delete(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            CarouselModelView model = new CarouselModelView() { ImageName = id };

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(CarouselModelView model)
        {
            if(model.ImageName.Trim()!="")
            {
                string response=  _imageHelper.DeleteImageAsync(model.ImageName);
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
