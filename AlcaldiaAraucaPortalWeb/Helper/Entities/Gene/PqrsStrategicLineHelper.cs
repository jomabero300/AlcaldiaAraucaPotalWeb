﻿using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class PqrsStrategicLineHelper : IPqrsStrategicLineHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsStrategicLineHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineUserComboAsync()
        {
            var modelI =await( from p in _context.PqrsStrategicLines
                         from e in _context.PqrsUserStrategicLines
                         where p.PqrsStrategicLineId == e.PqrsStrategicLineId
                         select new { PqrsStrategicLineId = p.PqrsStrategicLineId, PqrsStrategicLineName = p.PqrsStrategicLineName }).ToListAsync();

            List<PqrsStrategicLine> model;

            model = modelI.Select(b => new PqrsStrategicLine()
                                {
                                    PqrsStrategicLineId=b.PqrsStrategicLineId,
                                    PqrsStrategicLineName=b.PqrsStrategicLineName
                                }).ToList();

            model.Add(new PqrsStrategicLine { PqrsStrategicLineId = 0, PqrsStrategicLineName = "[Seleccione una Linea..]" });

            return model.OrderBy(m => m.PqrsStrategicLineName).ToList();
        }

        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineComboAsync()
        {
            var model = await _context.PqrsStrategicLines.ToListAsync();

            model.Add(new PqrsStrategicLine { PqrsStrategicLineId = 0, PqrsStrategicLineName = "[Seleccione un linea..]" });

            return model.OrderBy(m => m.PqrsStrategicLineName).ToList();
        }
    }
}
