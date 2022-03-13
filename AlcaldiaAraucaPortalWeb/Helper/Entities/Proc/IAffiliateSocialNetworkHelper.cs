using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public interface IAffiliateSocialNetworkHelper
    {
        Task<List<AffiliateSocialNetworkViewModel>> StatisticsReportAsync(AffiliateSocialNetworkViewModel model);
    }
}
