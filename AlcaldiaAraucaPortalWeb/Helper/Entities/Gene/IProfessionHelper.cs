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
        Task<List<Profession>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        Task<List<Profession>> ListAsync();
    }
}
