using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Affiliate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Proc
{
    public class AffiliateSocialNetworkHelper : IAffiliateSocialNetworkHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateSocialNetworkHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AffiliateSocialNetworkViewModel>> StatisticsReportAsync(AffiliateSocialNetworkViewModel model)
        {
            var respuest =model.SocialNetworkId==0?
                            await _context.AffiliateSocialNetworks
                                            .Include(a => a.SocialNetwork)
                                            .GroupBy(a=>new { a.SocialNetworkId,a.SocialNetwork.SocialNetworkName})
                                            .OrderBy(a=>a.Key.SocialNetworkName)
                                            .Select(a=>new {a.Key,Total=a.Count() })
                                            .ToListAsync():
                             await _context.AffiliateSocialNetworks
                                            .Include(a => a.SocialNetwork)
                                            .Where(a => a.SocialNetworkId == model.SocialNetworkId)
                                            .GroupBy(a=>new { a.SocialNetworkId,a.SocialNetwork.SocialNetworkName})
                                            .OrderBy(a=>a.Key.SocialNetworkName)
                                            .Select(a=>new {a.Key,Total=a.Count() })
                                            .ToListAsync();

            List<AffiliateSocialNetworkViewModel> asn = respuest.Select(a => new AffiliateSocialNetworkViewModel
            {
                SocialNetworkId=a.Key.SocialNetworkId,
                SocialNetworkName=a.Key.SocialNetworkName,
                Total=a.Total
            }).ToList();

            return asn;
        }
    }
}
