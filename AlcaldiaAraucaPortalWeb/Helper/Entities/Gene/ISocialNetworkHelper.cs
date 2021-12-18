using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface ISocialNetworkHelper
    {
        Task<List<SocialNetwork>> ComboAsync();
        Task<List<SocialNetwork>> ComboAsync(string[] SocialNetwork);
        Task<List<SocialNetwork>> ListAsync();
        Task<SocialNetwork> ByIdAsync(int id);
        Task<Response> AddUpdateAsync(SocialNetwork model);
        Task<Response> DeleteAsync(int id);
    }
}
