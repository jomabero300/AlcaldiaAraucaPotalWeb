using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public class GroupCommunityHelper: IGroupCommunityHelper
    {
        private readonly ApplicationDbContext _context;

        public GroupCommunityHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Response> AddUpdateAsync(GroupCommunity model)
        {
            if (model.GroupCommunityId == 0)
            {
                _context.GroupCommunity.Add(model);
            }
            else
            {
                _context.GroupCommunity.Update(model);
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

        public async Task<List<GroupCommunity>> ByIdAffiliateAsync(int id)
        {
            var group = await _context.AffiliateGroupCommunities.Where(a => a.AffiliateId == id).Select(a => a.GroupCommunityId).ToListAsync();

            var model = await _context.GroupCommunity.Where(g => !group.Contains(g.GroupCommunityId)).ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId= 0, GroupCommunityName= "[Seleccione un grupo comunitario..]" });

            return model.OrderBy(g => g.GroupCommunityName).ToList();
        }

        public async Task<GroupCommunity> ByIdAsync(int id)
        {
            var model = await _context.GroupCommunity.Include(g=>g.State).FirstOrDefaultAsync(a => a.GroupCommunityId == id);

            return model;
        }

        public async Task<List<GroupCommunity>> ComboAsync()
        {
            var model = await _context.GroupCommunity.Where(g=>g.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId = 0, GroupCommunityName = "[Seleccione un grupo comunitario..]" });

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }
        public async Task<List<GroupCommunity>> ComboAsync(string[] GroupCommunity)
        {
            var model = await _context.GroupCommunity.Where(g=>g.State.StateName.Equals("Activo") && !GroupCommunity.Contains(g.GroupCommunityName)).ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId = 0, GroupCommunityName = "[Seleccione un grupo comunitario..]" });

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }

        public async Task<List<GroupCommunity>> ComboReportAsync()
        {
            var model = await _context.GroupCommunity.Where(g => g.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId = 0, GroupCommunityName = "[Todos los grupo comunitarios..]" });

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.GroupCommunity.Where(a => a.GroupCommunityId == id).FirstOrDefaultAsync();

            try
            {
                _context.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;
        }

        public async Task<List<GroupCommunity>> ListAsync()
        {
            var model = await _context.GroupCommunity.Include(g=>g.State).ToListAsync();

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }

        public async Task<List<GroupCommunityViewModel>> StatisticsReportAsync(GroupCommunityViewModel model)
        {
            var response = model.GroupCommunityId==0?
                        await _context.AffiliateGroupCommunities
                                 .Include(g => g.GroupCommunity)
                                 .GroupBy(g => new { g.GroupCommunityId, g.GroupCommunity.GroupCommunityName })
                                .Select(g => new { g.Key, Total = g.Count() })
                                 .ToListAsync():
                        await _context.AffiliateGroupCommunities
                                 .Include(g => g.GroupCommunity)
                                 .Where(g => g.GroupCommunityId == model.GroupCommunityId)
                                 .GroupBy(g => new { g.GroupCommunityId, g.GroupCommunity.GroupCommunityName })
                                 .Select(g => new { g.Key, Total = g.Count() })
                                 .ToListAsync();
            List<GroupCommunityViewModel> report = response.Select(a => new GroupCommunityViewModel
            {
                GroupCommunityId=a.Key.GroupCommunityId,
                GroupCommunityName=a.Key.GroupCommunityName,
                Total=a.Total
            }).ToList();

            return report;
        }
    }
}
