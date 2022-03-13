using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class PqrsStrategicLineSectorHelper : IPqrsStrategicLineSectorHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsStrategicLineSectorHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PqrsStrategicLineSector>> ComboAsync(int pqrsStrategicLineId)
        {
            var model = await _context.PqrsStrategicLineSectors.Where(p => p.PqrsStrategicLineId == pqrsStrategicLineId).ToListAsync();

            model.Add(new PqrsStrategicLineSector { PqrsStrategicLineSectorId = 0, PqrsStrategicLineSectorName = "[Seleccione un Sector..]" });

            return model.OrderBy(m => m.PqrsStrategicLineSectorName).ToList();
        }

        public async Task<PqrsStrategicLineSector> ByNameAsync(string pqrsStrategicLineSectorName,int PqrsStrategicLineId)
        {
            var model = await _context.PqrsStrategicLineSectors.Where(p => p.PqrsStrategicLineSectorName == pqrsStrategicLineSectorName && p.PqrsStrategicLineId==PqrsStrategicLineId).FirstOrDefaultAsync();

            return model;
        }

        public async Task<PqrsStrategicLineSector> ByIdAsync(int pqrsStrategicLineSectorId)
        {
            var model = await _context.PqrsStrategicLineSectors.Where(p => p.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<PqrsStrategicLineSector>> ListAsync()
        {
            return await _context.PqrsStrategicLineSectors
                                 .Include(x=>x.PqrsStrategicLine)
                                 .OrderBy(x=>x.PqrsStrategicLineSectorId)
                                 .ToListAsync();
        }

        public PqrsStrategicLineSector ById(int pqrsStrategicLineSectorId)
        {
            var model = _context.PqrsStrategicLineSectors.Include(p=>p.PqrsStrategicLine).Where(p => p.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId).FirstOrDefault();

            return model;
        }
    }
}
