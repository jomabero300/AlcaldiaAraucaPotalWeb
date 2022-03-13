using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Susc
{
    public interface ISubscriberSectorHelper
    {
        Task<List<SubscriberSector>> BySectorIdAsync(int pqrsStrategicLineSectorId);
        Task<List<SubscriberSector>> BySubSectorAsync();
        Task<Response> AddUpdateAsync(List<SubscriberSector> model);
    }
}
