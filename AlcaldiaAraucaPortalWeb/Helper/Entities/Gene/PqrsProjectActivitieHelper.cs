using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class PqrsProjectActivitieHelper : IPqrsProjectActivitieHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsProjectActivitieHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(PqrsProjectActivitie model)
        {
            if(model.PqrsProjectActivitieId==0)
            {
                _context.PqrsProjectActivities.Add(model);
            }
            else
            {
                _context.PqrsProjectActivities.Update(model);
            }

            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este proyecto.";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }
            }
            catch (Exception exception)
            {
                response.Message = exception.Message;
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.PqrsProjectActivities.Where(a => a.PqrsProjectActivitieId == id).FirstOrDefaultAsync();

            try
            {
                _context.PqrsProjectActivities.Remove(model);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este proyecto.";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }
            }
            catch (Exception exception)
            {
                response.Message = exception.Message;
            }

            return response;

        }
    }
}
