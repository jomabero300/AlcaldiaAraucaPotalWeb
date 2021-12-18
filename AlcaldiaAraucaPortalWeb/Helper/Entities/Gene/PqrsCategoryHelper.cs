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
    public class PqrsCategoryHelper : IPqrsCategoryHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsCategoryHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Response> AddUpdateAsync(PqrsCategory model)
        {
            if (model.PqrsCategoryId == 0)
            {
                _context.PqrsCategories.Add(model);
            }
            else
            {
                _context.PqrsCategories.Update(model);
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

        public async Task<PqrsCategory> ByIdAsync(int id)
        {
            var model = await _context.PqrsCategories.Include(g => g.State).FirstOrDefaultAsync(a => a.PqrsCategoryId == id);

            return model;
        }

        public async Task<List<PqrsCategory>> ComboAsync()
        {
            var model = await _context.PqrsCategories.ToListAsync();

            model.Add(new PqrsCategory { PqrsCategoryId = 0, PqrsCategoryName = "[Seleccione una Categoría..]" });

            return model.OrderBy(m => m.PqrsCategoryName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.PqrsCategories.Where(a => a.PqrsCategoryId== id).FirstOrDefaultAsync();

            try
            {
                _context.PqrsCategories.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;

        }

        public async Task<List<PqrsCategory>> ListAsync()
        {
            var model = await _context.PqrsCategories.Include(g => g.State).ToListAsync();

            return model.OrderBy(m => m.PqrsCategoryName).ToList();
        }

    }
}
