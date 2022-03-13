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
    public class GroupProductiveHelper : IGroupProductiveHelper
    {
        private readonly ApplicationDbContext _context;

        public GroupProductiveHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> AddUpdateAsync(GroupProductive model)
        {
            if (model.GroupProductiveId == 0)
            {
                _context.GroupProductive.Add(model);
            }
            else
            {
                _context.GroupProductive.Update(model);
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
        public async Task<GroupProductive> ByIdAsync(int id)
        {
            var model = await _context.GroupProductive.Include(g=>g.State).FirstOrDefaultAsync(a => a.GroupProductiveId== id);

            return model;
        }
        public async Task<List<GroupProductive>> ByIdAffiliateAsync(int id)
        {
            var affiliateGrupoProductive = await _context.AffiliateGroupProductives.Where(a => a.AffiliateId == id).Select(a=>a.GroupProductiveId).ToListAsync();
            
            var model = await _context.GroupProductive.Where(g=>!affiliateGrupoProductive.Contains(g.GroupProductiveId)).ToListAsync();

            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = "[Seleccione un Grupo..]" });

            return model.OrderBy(g=>g.GroupProductiveName).ToList();
        }

        public async Task<List<GroupProductive>> ComboAsync()
        {
            var model = await _context.GroupProductive.Where(g=>g.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = "[Seleccione un Grupo..]" });

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }
        public async Task<List<GroupProductive>> ComboAsync(string[] groupProductives)
        {

            var model = await _context.GroupProductive.Where(g => g.State.StateName.Equals("Activo") && !groupProductives.Contains(g.GroupProductiveName)).ToListAsync();

            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = "[Seleccione un grupo productivo..]" });

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }
        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.GroupProductive.Where(a => a.GroupProductiveId == id).FirstOrDefaultAsync();

            try
            {
                _context.GroupProductive.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;
        }
        public async Task<List<GroupProductive>> ListAsync()
        {
            var model = await _context.GroupProductive.Include(g=>g.State).ToListAsync();

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }

        public async Task<List<GroupProductive>> ComboReportAsync()
        {
            var model = await _context.GroupProductive.Where(g => g.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = "[Todos los Grupo..]" });

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }
    }
}
