using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public interface IGroupCommunityHelper
    {
        Task<Response> AddUpdateAsync(GroupCommunity model);
        Task<GroupCommunity> ByIdAsync(int id);
        Task<List<GroupCommunity>> ByIdAffiliateAsync(int id);
        Task<List<GroupCommunity>> ComboAsync();
        Task<List<GroupCommunity>> ComboAsync(string[] GroupCommunity);
        Task<List<GroupCommunity>> ComboReportAsync();
        Task<List<GroupCommunityViewModel>> StatisticsReportAsync(GroupCommunityViewModel model);
        Task<Response> DeleteAsync(int id);
        Task<List<GroupCommunity>> ListAsync();
    }
}
