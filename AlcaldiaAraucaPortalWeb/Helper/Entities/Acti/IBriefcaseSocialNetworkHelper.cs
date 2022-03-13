using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Acti
{
    public interface IBriefcaseSocialNetworkHelper
    {
        Task<List<SocialNetwork>> SocialNetworkByIdAsync(int id);
    }
}
