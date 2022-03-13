using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Acti
{
    public class BriefcaseSocialNetworkHelper: IBriefcaseSocialNetworkHelper
    {
        private readonly ApplicationDbContext _context;

        public BriefcaseSocialNetworkHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<SocialNetwork>> SocialNetworkByIdAsync(int id)
        {
            var briefcaseS = await _context.BriefcaseSocialNetworks.Where(b => b.BriefcaseId == id).ToListAsync();
            int[] social = briefcaseS.Select(b => b.SocialNetworkId).ToArray();
            var model = await _context.SocialNetwork.Where(s => !social.Contains(s.SocialNetworkId)).ToListAsync();

            return model;

        }
    }
}
