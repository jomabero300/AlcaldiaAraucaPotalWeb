using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public class AffiliateProfessionHelper : IAffiliateProfessionHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateProfessionHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfessionViewModel>> StatisticsReportAsync(ProfessionViewModel model)
        {
            var profesiones = model.ProfessionId != 0 ?
                            await _context.AffiliateProfessions
                                          .Include(a => a.Profession)
                                          .Where(a => a.ProfessionId == model.ProfessionId)
                                          .GroupBy(a => new { a.ProfessionId, a.Profession.ProfessionName })
                                          .Select(a => new { a.Key, Total = a.Count() })
                                          .ToListAsync() :
                             await _context.AffiliateProfessions
                                          .Include(a => a.Profession)
                                          .GroupBy(a => new { a.ProfessionId, a.Profession.ProfessionName })
                                          .Select(a => new { a.Key, Total = a.Count() })
                                          .ToListAsync();

            List<ProfessionViewModel> profe = profesiones.Select(a => new ProfessionViewModel
            {
                ProfessionId = a.Key.ProfessionId,
                ProfessionName = a.Key.ProfessionName,
                Total = a.Total
            }).ToList();
            return profe;
        }
    }
}
