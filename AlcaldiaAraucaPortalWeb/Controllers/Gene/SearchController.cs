using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearcheViewModel model)
        {
            return RedirectToAction(nameof(Search), new { filter = model.Search.ToUpper() });
        }

        public IActionResult Search(string filter)
        {
            var modelConten = _context.Contents.Where(x => x.ContentTitle.ToUpper().Contains(filter) || x.ContentText.ToUpper().Contains(filter)).ToList();
            //var modelProfes = _context.AffiliateProfessions
            //                                    .Include(x=>x.Affiliate)
            //                          .Where(x => x.Affiliate.Name.ToUpper().Contains(filter) ).ToList();
            var modelProfes = ((from a in _context.Affiliates
                                where a.Name.ToUpper().Contains(filter)
                                select new { a.AffiliateId, a.Name, a.Address, a.ImagePath }).Union
                              (
                                from b in _context.Affiliates
                                join pr in _context.AffiliateProfessions on b.AffiliateId equals pr.AffiliateId
                                join p in _context.Professions on pr.ProfessionId equals p.ProfessionId
                                where p.ProfessionName.ToUpper().Contains(filter)
                                select new { b.AffiliateId, b.Name, b.Address, b.ImagePath })).ToList();




            List<FilterViewModel> model = new List<FilterViewModel>();
            if(modelConten.Count>0)
            {
                model = modelConten.Select(x => new FilterViewModel
                {
                    id=x.ContentId,
                    Name=x.ContentTitle,
                    descrition=x.ContentText,
                    ImageUrl=x.ContentUrlImg,
                    Model="C"
                }).ToList();
            }
            if(modelProfes.Count>0)
            {
                modelProfes.Distinct();

                foreach (var item in modelProfes)
                {

                    model.Add(new FilterViewModel
                    {
                        id = item.AffiliateId,
                        Name = item.Name,
                        descrition = item.Address,
                        ImageUrl = item.ImagePath,
                        Model = "A"
                    });
                }
            }

            return View(model);
        }
    }
}
