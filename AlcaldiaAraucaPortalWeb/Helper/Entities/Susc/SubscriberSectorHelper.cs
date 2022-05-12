using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Susc
{
    public class SubscriberSectorHelper : ISubscriberSectorHelper
    {
        private readonly ApplicationDbContext _context;

        public SubscriberSectorHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(List<SubscriberSector> model)
        {
            _context.SubscriberSectors.UpdateRange(model);

            var response = new Response() { Succeeded = true };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;

        }

        public async Task<List<SubscriberSector>> BySectorIdAsync(int pqrsStrategicLineSectorId)
        {
            var stateId = await _context.States.Where(s => s.StateName == "Activo" && s.StateType == "G").FirstOrDefaultAsync();

            List<SubscriberSector> model = await _context.SubscriberSectors
                                                        .Where(s => 
                                                               s.Subscriber.EmailConfirmed == true && 
                                                               s.Subscriber.StateId == stateId.StateId && 
                                                               s.StateId == stateId.StateId &&
                                                               s.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId)
                                                        .ToListAsync();
            if(model !=null)
            {
                model.ForEach(m => m.SendUrl = true);
            }

            return model;
        }

        public async Task<List<SubscriberSector>> BySubSectorAsync()
        {
            State stateId = await _context.States.Where(s => s.StateName == "Activo" && s.StateType == "G").FirstOrDefaultAsync();
            List<SubscriberSector> model = await _context.SubscriberSectors.Include(s => s.Subscriber)
                                                        .Where(s => s.Subscriber.EmailConfirmed == true &&
                                                                s.Subscriber.StateId == stateId.StateId &&
                                                                s.StateId == stateId.StateId &&
                                                                s.SendUrl == true)
                                                        .ToListAsync();
            return model;
        }
    }
}
