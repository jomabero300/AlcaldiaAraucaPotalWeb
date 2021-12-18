using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public class AffiliateHelper : IAffiliateHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> AddUpdateAsync(Affiliate model)
        {
            if (model.AffiliateId == 0)
            {
                _context.Affiliates.Add(model);
            }
            else
            {
                _context.Affiliates.Update(model);
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
        public async Task<Affiliate> AffiliateByIdAsync(int id)
        {
            var model = await _context.Affiliates
                                      .Include(a=>a.ApplicationUser)
                                      .Include(a=>a.GroupCommunities).ThenInclude(a=>a.GroupCommunity)
                                      .Include(a=>a.GroupProductives).ThenInclude(a=>a.GroupProductive)
                                      .Include(a=>a.Professions).ThenInclude(a=>a.Profession)
                                      .Include(a=>a.SocialNetworks).ThenInclude(a=>a.SocialNetwork)
                                      .FirstOrDefaultAsync(a=>a.AffiliateId==id);

            return model;
        }
        public async Task<List<Affiliate>> AffiliateListAsync()
        {
            List<Affiliate> model = await _context.Affiliates.Include(a=>a.ApplicationUser).ToListAsync();
            return model.OrderBy(m => m.Name).ToList();
        }
        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.Affiliates.Where(a => a.AffiliateId == id).FirstOrDefaultAsync();

            try
            {
                _context.Affiliates.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;
        }

    }
}
