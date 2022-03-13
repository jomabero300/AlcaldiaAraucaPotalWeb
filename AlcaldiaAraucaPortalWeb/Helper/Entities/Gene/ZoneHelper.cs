using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class ZoneHelper : IZoneHelper
    {
        private readonly ApplicationDbContext _context;

        public ZoneHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Zone>> ComboAsync()
        {
            var model = await _context.Zones.ToListAsync();

            model.Add(new Zone { ZoneId = 0, ZoneName = "[Seleccione una zona..]" });

            return model.OrderBy(m => m.ZoneName).ToList();

        }
    }
}
