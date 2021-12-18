using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class StateHelper : IStateHelper
    {
        private readonly ApplicationDbContext _context;

        public StateHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<State>> StateComboAsync(string stateType)
        {
            var model = await _context.States.Where(s => s.StateType == stateType).ToListAsync();

            model.Add(new State { StateId = 0, StateName = "[Seleccione un genero..]" });

            return model.OrderBy(m => m.StateName).ToList();
        }

        public async Task<int> StateIdAsync(string stateType, string stateName)
        {
            var model = await _context.States.Where(s => s.StateType == stateType && s.StateName.Equals(stateName)).FirstOrDefaultAsync();

            return model.StateId;
        }
        public async Task<List<State>> StateAsync(string stateType, string[] stateName)
        {
            var model = await _context.States.Where(s => s.StateType == stateType && stateName.Contains(s.StateName)).ToListAsync();
            //var state = await _context.States.Where(s => s.StateName == "Activo" || s.StateName == "Inactivo").Select(s=>s.StateId).ToListAsync();
            //var model =await (from e in _context.States
            //            where
            //                stateName.Contains(e.StateName)
            //            select e).ToListAsync();
            return model;
        }

    }
}
