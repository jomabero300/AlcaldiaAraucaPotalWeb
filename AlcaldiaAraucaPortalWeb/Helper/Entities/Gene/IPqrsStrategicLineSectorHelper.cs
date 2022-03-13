using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsStrategicLineSectorHelper
    {
        Task<List<PqrsStrategicLineSector>> ComboAsync(int pqrsStrategicLineId);
        Task<PqrsStrategicLineSector> ByNameAsync(string pqrsStrategicLineSectorName, int PqrsStrategicLineId);
        Task<PqrsStrategicLineSector> ByIdAsync(int pqrsStrategicLineSectorId);
        PqrsStrategicLineSector ById(int pqrsStrategicLineSectorId);
        Task<List<PqrsStrategicLineSector>> ListAsync();
    }
}
