using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsUserStrategicLineHelper
    {
        Task<List<PqrsStrategicLine>> PqrsStrategicLineIdAsync(string userId);

        Task<PqrsStrategicLine> PqrsStrategicLineBIdAsync(string userId);
    }
}
