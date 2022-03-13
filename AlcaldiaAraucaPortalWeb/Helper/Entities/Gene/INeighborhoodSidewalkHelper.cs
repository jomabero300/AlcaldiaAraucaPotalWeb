using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface INeighborhoodSidewalkHelper
    {
        Task<List<NeighborhoodSidewalk>> ComboAsync(int CommuneTownshipId);
    }
}
