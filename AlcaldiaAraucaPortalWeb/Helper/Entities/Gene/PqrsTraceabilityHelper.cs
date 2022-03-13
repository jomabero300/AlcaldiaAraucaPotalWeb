using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class PqrsTraceabilityHelper : IPqrsTraceabilityHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsTraceabilityHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> DeleteAsync(int idPqrsId)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.PqrsTraceabilities.Where(a => a.PqrsId == idPqrsId).ToListAsync();

            try
            {
                _context.PqrsTraceabilities.RemoveRange(model);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este proyecto.";
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

        public async Task<Response> DeleteIdAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.PqrsTraceabilities.Where(a => a.PqrsTraceabilityId == id).FirstOrDefaultAsync();

            try
            {
                _context.PqrsTraceabilities.Remove(model);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    response.Message = "Ya existe este proyecto.";
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

        public async Task<List<PqrsLineCategoryModelViewModel>> StatisticsReportAsync(PqrsLineCategoryViewModel model)
        {
            var rsponse = (model.PqrsCategoryId == 0 && model.PqrsStrategicLineId == 0) ?
                                await _context.PqrsTraceabilities
                                                      .Include(p => p.Pqrs).ThenInclude(p => p.PqrsCategory)
                                                      .Include(p => p.PqrsUserStrategicLine).ThenInclude(p => p.PqrsStrategicLine)
                                             .Where(p => p.Pqrs.PqrsDate >= model.PqrsDateStart &&
                                                         p.Pqrs.PqrsDate <= model.PqrsDateEnd)
                                             .GroupBy(p => new { p.PqrsUserStrategicLine.PqrsStrategicLine.PqrsStrategicLineName, p.Pqrs.PqrsCategory.PqrsCategoryName })
                                             .Select(p => new { p.Key, Total = p.Count() })
                                             .ToListAsync() :
                             (model.PqrsCategoryId != 0 && model.PqrsStrategicLineId != 0) ?
                                    await _context.PqrsTraceabilities
                                 .Include(p => p.Pqrs).ThenInclude(p => p.PqrsCategory)
                                 .Include(p => p.PqrsUserStrategicLine).ThenInclude(p => p.PqrsStrategicLine)
                                 .Where(p => p.Pqrs.PqrsDate >= model.PqrsDateStart &&
                                             p.Pqrs.PqrsDate <= model.PqrsDateEnd &&
                                             p.PqrsUserStrategicLine.PqrsStrategicLineId == model.PqrsStrategicLineId &&
                                             p.Pqrs.PqrsCategoryId == model.PqrsCategoryId)
                                 .GroupBy(p => new { p.PqrsUserStrategicLine.PqrsStrategicLine.PqrsStrategicLineName, p.Pqrs.PqrsCategory.PqrsCategoryName })
                                 .Select(p => new { p.Key, Total = p.Count() })
                                 .ToListAsync() :

                                            (model.PqrsCategoryId != 0 ?
                                            await _context.PqrsTraceabilities
                                            .Include(p => p.Pqrs).ThenInclude(p => p.PqrsCategory)
                                            .Include(p => p.PqrsUserStrategicLine).ThenInclude(p => p.PqrsStrategicLine)
                                            .Where(p => p.Pqrs.PqrsCategoryId == model.PqrsCategoryId &&
                                                        p.Pqrs.PqrsDate >= model.PqrsDateStart &&
                                                        p.Pqrs.PqrsDate <= model.PqrsDateEnd)
                                            .GroupBy(p => new { p.PqrsUserStrategicLine.PqrsStrategicLine.PqrsStrategicLineName, p.Pqrs.PqrsCategory.PqrsCategoryName })
                                            .Select(p => new { p.Key, Total = p.Count() })
                                            .ToListAsync() :
                                                await _context.PqrsTraceabilities
                                                .Include(p => p.Pqrs).ThenInclude(p => p.PqrsCategory)
                                                .Include(p => p.PqrsUserStrategicLine).ThenInclude(p => p.PqrsStrategicLine)
                                                .Where(p => p.PqrsUserStrategicLine.PqrsStrategicLineId == model.PqrsStrategicLineId &&
                                                            p.Pqrs.PqrsDate >= model.PqrsDateStart &&
                                                            p.Pqrs.PqrsDate <= model.PqrsDateEnd)
                                                .GroupBy(p => new { p.PqrsUserStrategicLine.PqrsStrategicLine.PqrsStrategicLineName, p.Pqrs.PqrsCategory.PqrsCategoryName })
                                                .Select(p => new { p.Key, Total = p.Count() })
                                                .ToListAsync()
                                                );
            List<PqrsLineCategoryModelViewModel> rpt = rsponse.Select(R => new PqrsLineCategoryModelViewModel()
            {
                PqrsDateEnd = model.PqrsDateEnd,
                PqrsDateStart = model.PqrsDateStart,
                PqrsStrategicLineName = R.Key.PqrsStrategicLineName,
                PqrsCategoryName = R.Key.PqrsCategoryName,
                Total = R.Total
            }).ToList();

            return rpt;
        }
    }
}
