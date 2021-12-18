using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IGenderHelper
    {
        Task<Response> AddUpdateAsync(Gender model);
        Task<Gender> ByIdAsync(int id);
        Task<List<Gender>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        Task<List<Gender>> ListAsync();
    }
}
