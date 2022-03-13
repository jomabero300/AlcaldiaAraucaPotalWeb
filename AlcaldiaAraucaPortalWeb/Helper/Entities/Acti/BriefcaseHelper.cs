using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Acti
{
    public class BriefcaseHelper: IBriefcaseHelper
    {
        private readonly ApplicationDbContext _context;

        public BriefcaseHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Briefcase model)
        {
            if (model.BriefcaseId == 0)
            {
                _context.Briefcases.Add(model);
            }
            else
            {
                _context.Briefcases.Update(model);
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
                    response.Message= "Ya existe esta marca.";
                }
                else
                {
                    response.Message= dbUpdateException.InnerException.Message;
                }
            }
            catch (Exception exception)
            {
                response.Message= exception.Message;
            }
            return response;

        }

        public async Task<Briefcase> ByIdAsync(int id)
        {
            var model = await _context.Briefcases.Include(g => g.BriefcaseSocialNetworks).FirstOrDefaultAsync(a => a.BriefcaseId == id);

            return model;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.Briefcases.Where(a => a.BriefcaseId== id).FirstOrDefaultAsync();

            try
            {
                _context.Briefcases.Remove(model);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe esta marca.";
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

        public async Task<List<Briefcase>> ListAsync()
        {
            var model = await _context.Briefcases.Include(g => g.BriefcaseSocialNetworks).ThenInclude(g=>g.SocialNetwork).ToListAsync();

            return model.OrderBy(m => m.BriefcaseTitel).ToList();
        }
    }
}
