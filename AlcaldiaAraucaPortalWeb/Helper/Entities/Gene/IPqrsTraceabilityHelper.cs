using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsTraceabilityHelper
    {
        Task<Response> DeleteIdAsync(int id);
        Task<Response> DeleteAsync(int idPqrsId);
        Task<List<PqrsLineCategoryModelViewModel>> StatisticsReportAsync(PqrsLineCategoryViewModel model);
    }
}
