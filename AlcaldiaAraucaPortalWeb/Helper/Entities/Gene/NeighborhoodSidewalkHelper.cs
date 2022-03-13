using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class NeighborhoodSidewalkHelper : INeighborhoodSidewalkHelper
    {
        private readonly ApplicationDbContext _context;

        public NeighborhoodSidewalkHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NeighborhoodSidewalk>> ComboAsync(int CommuneTownshipId)
        {
            var model = await _context.NeighborhoodSidewalks.Where(g => g.CommuneTownshipId == CommuneTownshipId).ToListAsync();

            var zone = await _context.CommuneTownships.Include(c => c.Zone).Where(c => c.CommuneTownshipId == CommuneTownshipId).FirstOrDefaultAsync();

            var title = CommuneTownshipId.Equals(0)? "[Seleccione una opcion anterior...]" : (zone.Zone.ZoneName.Equals("Urbano") ? "[Seleccione una barrio...]" : "[Seleccione una vereda...]");


            model.Add(new NeighborhoodSidewalk { NeighborhoodSidewalkId = 0, NeighborhoodSidewalkName = title });

            return model.OrderBy(m => m.NeighborhoodSidewalkName).ToList();

        }
    }
}
