using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public interface IAffiliateGroupProductiveHelper
    {
        Task<Response> AddUpdateAsync(AffiliateGroupProductive model);
        Task<Response> AddUpdateListAsync(List<AffiliateGroupProductive> model);
        Task<List<AffiliateGroupProductive>> ByIdAsync(int id);
        Task<AffiliateGroupProductive> ByIdGruopProductiveAsync(int id);
        Task<Response> DeleteAsync(int AffiliateGroupProductiveId);

        Task<List<GroupProductiveViewModel>> StatisticsReportAsync(GroupProductiveViewModel model);
    }
}
