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
    public class SocialNetworkHelper : ISocialNetworkHelper
    {
        private readonly ApplicationDbContext _context;

        public SocialNetworkHelper(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddUpdateAsync(SocialNetwork model)
        {
            if (model.SocialNetworkId == 0)
            {
                _context.SocialNetwork.Add(model);
            }
            else
            {
                _context.SocialNetwork.Update(model);
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

        public async Task<SocialNetwork> ByIdAsync(int id)
        {
            var model = await _context.SocialNetwork.Include(g => g.State).FirstOrDefaultAsync(a => a.SocialNetworkId == id);

            return model;
        }

        public async Task<List<SocialNetwork>> ComboAsync()
        {
            var model = await _context.SocialNetwork.ToListAsync();

            model.Add(new SocialNetwork { SocialNetworkId = 0, SocialNetworkName = "[Seleccione una red social..]" });

            return model.OrderBy(m => m.SocialNetworkName).ToList();
        }
        public async Task<List<SocialNetwork>> ComboAsync(string[] SocialNetwork)
        {
            var model = await _context.SocialNetwork.Where(s=>!SocialNetwork.Contains(s.SocialNetworkName)).ToListAsync();

            model.Add(new SocialNetwork { SocialNetworkId = 0, SocialNetworkName = "[Seleccione una red social..]" });

            return model.OrderBy(m => m.SocialNetworkName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.SocialNetwork.Where(a => a.SocialNetworkId== id).FirstOrDefaultAsync();

            try
            {
                _context.SocialNetwork.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;
        }

        public async Task<List<SocialNetwork>> ListAsync()
        {
            var model = await _context.SocialNetwork.Include(g => g.State).ToListAsync();

            return model.OrderBy(m => m.SocialNetworkName).ToList();

        }
    }
}
