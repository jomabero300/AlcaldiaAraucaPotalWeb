using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public interface IAffiliateGroupProductiveHelper
    {
        Task<Response> AddUpdateAsync(AffiliateGroupProductive model);
        Task<List<AffiliateGroupProductive>> ByIdAsync(int id);
        Task<AffiliateGroupProductive> ByIdGruopProductiveAsync(int id);
        Task<Response> DeleteAsync(int AffiliateGroupProductiveId);
    }
}
