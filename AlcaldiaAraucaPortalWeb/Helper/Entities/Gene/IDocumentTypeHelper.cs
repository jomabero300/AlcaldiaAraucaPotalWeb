using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IDocumentTypeHelper
    {
        Task<Response> AddUpdateAsync(DocumentType model);
        Task<DocumentType> ByIdAsync(int id);
        Task<List<DocumentType>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        Task<List<DocumentType>> ListAsync();

    }
}
