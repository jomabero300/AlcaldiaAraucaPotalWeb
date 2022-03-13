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
    public class AffiliateGroupProductiveHelper : IAffiliateGroupProductiveHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateGroupProductiveHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(AffiliateGroupProductive model)
        {
            if (model.AffiliateGroupProductiveId == 0)
            {
                _context.AffiliateGroupProductives.Add(model);
            }
            else
            {
                _context.AffiliateGroupProductives.Update(model);
            }

            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                response.Succeeded = false;

                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este tipo de vehículo.";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<Response> AddUpdateListAsync(List<AffiliateGroupProductive> model)
        {
            if (model.FirstOrDefault().AffiliateGroupProductiveId == 0)
            {
                _context.AffiliateGroupProductives.AddRange(model);
            }
            else
            {
                _context.AffiliateGroupProductives.UpdateRange(model);
            }

            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                response.Succeeded = false;

                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este tipo de vehículo.";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<List<AffiliateGroupProductive>> ByIdAsync(int id)
        {
            var model = await _context.AffiliateGroupProductives.Include(a=>a.GroupProductive).Where(a => a.AffiliateId == id).ToListAsync();

            return model;
        }

        public async Task<AffiliateGroupProductive> ByIdGruopProductiveAsync(int id)
        {
            var model = await _context.AffiliateGroupProductives.Include(a => a.GroupProductive).Where(a => a.AffiliateGroupProductiveId == id).FirstOrDefaultAsync();

            return model;
        }

        public async Task<Response> DeleteAsync(int AffiliateGroupProductiveId)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.AffiliateGroupProductives.FindAsync(AffiliateGroupProductiveId);

            try
            {
                _context.AffiliateGroupProductives.Remove(model);

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException dbUpdateException)
            {
                response.Succeeded = false;

                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este tipo de vehículo.";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<List<GroupProductiveViewModel>> StatisticsReportAsync(GroupProductiveViewModel model)
        {
            var grupoProdutivos = model.GroupProductiveId == 0 ?
                                 await _context.AffiliateGroupProductives
                                              .Include(g => g.GroupProductive)
                                              .GroupBy(g => new { g.GroupProductiveId, g.GroupProductive.GroupProductiveName })
                                              .Select(g => new { g.Key, Total = g.Count() })
                                              .ToListAsync() :
                                 await _context.AffiliateGroupProductives
                                              .Include(g => g.GroupProductive)
                                              .Where(g => g.GroupProductiveId == model.GroupProductiveId)
                                              .GroupBy(g => new { g.GroupProductiveId, g.GroupProductive.GroupProductiveName })
                                              .Select(g => new { g.Key, Total = g.Count() })
                                              .ToListAsync();

            List<GroupProductiveViewModel> groupProductives = grupoProdutivos.Select(g => new GroupProductiveViewModel
            {
                GroupProductiveId = g.Key.GroupProductiveId,
                GroupProductiveName = g.Key.GroupProductiveName,
                Total = g.Total
            }).ToList();

            return groupProductives;
        }
    }
}
