using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Cont
{
    public class ContentOdsHelper : IContentOdsHelper
    {
        private readonly ApplicationDbContext _context;

        public ContentOdsHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContentOds>> ByIdAsync(int SectorId)
        {
            var model = await _context.ContentOds.Where(c => c.PqrsStrategicLineSectorId == SectorId).ToListAsync();

            return model.OrderBy(c => c.ContentOdsId).ToList();

        }
    }
}
