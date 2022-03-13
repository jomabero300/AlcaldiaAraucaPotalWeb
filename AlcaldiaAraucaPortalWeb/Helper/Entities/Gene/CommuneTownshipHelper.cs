using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class CommuneTownshipHelper : ICommuneTownshipHelper
    {
        private readonly ApplicationDbContext _context;

        public CommuneTownshipHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<CommuneTownship>> ComboAsync(int zoneId)
        {
            var model = await _context.CommuneTownships.Where(g => g.ZoneId == zoneId).ToListAsync();

            var zone = _context.Zones.Where(z => z.ZoneId == zoneId).FirstOrDefault();

            var title = zoneId.Equals(0)? "[Seleccione una zona primero...]" : ( zone.ZoneName.Equals("Urbano")? "[Seleccione una comuna...]": "[Seleccione un corregimiento...]");
            
            model.Add(new CommuneTownship { CommuneTownshipId = 0, CommuneTownshipName = title });

            return model.OrderBy(m => m.CommuneTownshipId).ToList();
        }
    }
}
