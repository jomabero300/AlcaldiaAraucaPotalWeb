using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IProfessionHelper
    {
        Task<Response> AddUpdateAsync(Profession model);
        Task<Profession> ByIdAsync(int id);
        Task<List<Profession>> ByIdAffiliateAsync(int id);
        Task<List<Profession>> ComboAsync();
        Task<List<Profession>> ComboReportAsync();
        Task<List<Profession>> ComboAsync(string[] GroupProfession);
        Task<Response> DeleteAsync(int id);
        Task<List<Profession>> ListAsync();
    }
}
