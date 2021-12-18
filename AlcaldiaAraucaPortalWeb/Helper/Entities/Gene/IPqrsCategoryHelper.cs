using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsCategoryHelper
    {
        Task<Response> AddUpdateAsync(PqrsCategory model);
        Task<PqrsCategory> ByIdAsync(int id);
        Task<List<PqrsCategory>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        Task<List<PqrsCategory>> ListAsync();

    }
}
