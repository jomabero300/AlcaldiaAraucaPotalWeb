using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsProjectActivitieHelper
    {
        Task<Response> AddUpdateAsync(PqrsProjectActivitie model);
        //Task<DocumentType> ByIdAsync(int id);
        //Task<List<DocumentType>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        //Task<List<DocumentType>> ListAsync();
    }
}
