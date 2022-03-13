using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public interface IAffiliateProfessionHelper
    {
        Task<List<ProfessionViewModel>> StatisticsReportAsync(ProfessionViewModel model);
    }
}
