using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsAttachmentsHelper
    {
        Task<Response> AddUpdateAsync(PqrsAttachments model);
        Task<Response> DeleteAsync(int id);
        Task<Response> DeletePqrsIdAsync(int id);
        Task<List<PqrsAttachments>> ListAsync(int pqrsId);

    }
}
