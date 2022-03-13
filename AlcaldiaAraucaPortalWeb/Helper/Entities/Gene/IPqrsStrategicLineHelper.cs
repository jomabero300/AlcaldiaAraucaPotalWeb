using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IPqrsStrategicLineHelper
    {
        Task<List<PqrsStrategicLine>> PqrsStrategicLineUserComboAsync();
        Task<List<PqrsStrategicLine>> PqrsStrategicLineComboAsync();
        Task<PqrsStrategicLine> ByNameAsync(string name);
    }
}
