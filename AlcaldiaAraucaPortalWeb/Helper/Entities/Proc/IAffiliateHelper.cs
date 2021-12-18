using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public interface IAffiliateHelper
    {
        Task<List<Affiliate>> AffiliateListAsync();
        Task<Affiliate> AffiliateByIdAsync(int id);
        Task<Response> AddUpdateAsync(Affiliate model);
        Task<Response> DeleteAsync(int id);
    }
}
