using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IRoleHelper
    {
        Task<List<IdentityRole>> ComboAsync();
    }
}
