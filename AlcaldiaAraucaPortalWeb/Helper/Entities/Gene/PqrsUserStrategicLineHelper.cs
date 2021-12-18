using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class PqrsUserStrategicLineHelper : IPqrsUserStrategicLineHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsUserStrategicLineHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineIdAsync(string userId)
        {
            var list = await _context.PqrsUserStrategicLines.Where(p => p.UserId == userId).Select(p => p.PqrsStrategicLineId).ToListAsync();
            var lista = (from l in _context.PqrsStrategicLines
                         where
                              !list.Contains(l.PqrsStrategicLineId)
                         select l).ToList();

            return lista;
        }
    }
}
