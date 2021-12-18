using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public interface IStateHelper
    {
        Task<List<State>> StateComboAsync(string stateType);
        Task<int> StateIdAsync(string stateType, string stateName);
        Task<List<State>> StateAsync(string stateType, string[] stateName);
    }
}
