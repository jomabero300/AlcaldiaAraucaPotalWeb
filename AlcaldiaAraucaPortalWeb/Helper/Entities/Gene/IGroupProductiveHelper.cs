using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IGroupProductiveHelper
    {
        Task<Response> AddUpdateAsync(GroupProductive model);
        Task<GroupProductive> ByIdAsync(int id);
        Task<List<GroupProductive>> ByIdAffiliateAsync(int id);
        Task<List<GroupProductive>> ComboAsync();
        Task<List<GroupProductive>> ComboReportAsync();
        Task<List<GroupProductive>> ComboAsync(string[] GroupProductives);
        Task<Response> DeleteAsync(int id);
        Task<List<GroupProductive>> ListAsync();
    }
}
