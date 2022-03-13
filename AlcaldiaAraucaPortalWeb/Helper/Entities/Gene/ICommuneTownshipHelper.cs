using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface ICommuneTownshipHelper
    {
        Task<List<CommuneTownship>> ComboAsync(int zoneId);
    }
}
