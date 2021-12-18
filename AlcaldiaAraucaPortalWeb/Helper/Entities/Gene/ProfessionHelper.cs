using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class ProfessionHelper : IProfessionHelper
    {
        private readonly ApplicationDbContext _context;
        public ProfessionHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> AddUpdateAsync(Profession model)
        {
            if (model.ProfessionId == 0)
            {
                _context.Professions.Add(model);
            }
            else
            {
                _context.Professions.Update(model);
            }
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

        public async Task<Profession> ByIdAsync(int id)
        {
            var model = await _context.Professions.Include(g => g.State).FirstOrDefaultAsync(a => a.ProfessionId == id);

            return model;

        }

        public async Task<List<Profession>> ComboAsync()
        {
            var model = await _context.Professions.Include(P=>P.State).Where(p=>p.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new Profession { ProfessionId = 0, ProfessionName = "[Seleccione una Profesión..]" });

            return model.OrderBy(m => m.ProfessionName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.Professions.Where(a => a.ProfessionId== id).FirstOrDefaultAsync();

            try
            {
                _context.Professions.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;
        }

        public async Task<List<Profession>> ListAsync()
        {
            var model = await _context.Professions.Include(g => g.State).ToListAsync();

            return model.OrderBy(m => m.ProfessionName).ToList();
        }
    }
}
