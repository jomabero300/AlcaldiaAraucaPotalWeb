using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Acti
{
    public interface IBriefcaseHelper
    {
        Task<Response> AddUpdateAsync(Briefcase model);
        Task<Briefcase> ByIdAsync(int id);

        Task<Response> DeleteAsync(int id);
        Task<List<Briefcase>> ListAsync();
    }
}
