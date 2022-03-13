using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Cont
{
    public interface IContentHelper
    {
        Task<List<Data.Entities.Cont.Content>> ListAsync(int SectorId);
        Task<List<ContentDetail>> ListDetailsAsync(int contentId);
        Task<ContentDetail> DetailsIdAsync(int ContentDetailsId);
        Task<Data.Entities.Cont.Content> ByIdAsync(int contentId);
        Task<Response> DeleteDetailsAsync(int id);
    }
}
