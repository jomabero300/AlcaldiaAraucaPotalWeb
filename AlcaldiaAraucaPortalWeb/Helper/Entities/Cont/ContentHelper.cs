using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Cont
{
    public class ContentHelper : IContentHelper
    {
        private readonly ApplicationDbContext _context;

        public ContentHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Content> ByIdAsync(int contentId)
        {
            var model = await _context.Contents.FindAsync(contentId);
            return model;
        }

        public async Task<Models.Response> DeleteDetailsAsync(int id)
        {
            var response = new Models.Response() { Succeeded = true };

            var model = await _context.ContentDetails.Where(a => a.ContentDetailsId == id).FirstOrDefaultAsync();

            try
            {
                _context.ContentDetails.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;

        }

        public async Task<ContentDetail> DetailsIdAsync(int ContentDetailsId)
        {
            ContentDetail model = await _context.ContentDetails.FindAsync(ContentDetailsId);

            return model;
        }

        public async Task<List<Content>> ListAsync(int SectorId)
        {
            State estate = await _context.States.Where(s => s.StateName.Equals("Activo")).FirstOrDefaultAsync();

            List<Content> model = await _context.Contents.Where(c => c.PqrsStrategicLineSectorId == SectorId && c.StateId==estate.StateId).ToListAsync();

            return model.OrderByDescending(m => m.ContentDate).ToList();
        }

        public async Task<List<ContentDetail>> ListDetailsAsync(int contentId)
        {
            var model = await _context.ContentDetails
                                      .Where(c => c.ContentId == contentId)
                                      .OrderBy(c=>c.ContentDetailsId)
                                      .ToListAsync();
            return model;

        }
    }
}
