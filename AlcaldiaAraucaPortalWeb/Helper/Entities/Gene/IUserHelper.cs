using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IUserHelper
    {
        Task<List<ApplicationUser>> UsersComboAsync();
        IdentityUser UserByIdEmailAsync(string id);
    }
}
