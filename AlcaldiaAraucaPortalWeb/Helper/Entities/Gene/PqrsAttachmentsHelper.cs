using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class PqrsAttachmentsHelper : IPqrsAttachmentsHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsAttachmentsHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(PqrsAttachments model)
        {
            if (model.PqrsAttachmentId == 0)
            {
                _context.PqrsAttachments.Add(model);
            }
            else
            {
                _context.PqrsAttachments.Update(model);
            }
            var response = new Response() { Succeeded = true };
            try
            {
                await _context.SaveChangesAsync();
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

        public async Task<PqrsAttachments> ByIdAsync(int id)
        {
            var model = await _context.PqrsAttachments.FirstOrDefaultAsync(p => p.PqrsAttachmentId == id);

            return model;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.PqrsAttachments.FirstOrDefaultAsync(p => p.PqrsAttachmentId == id);

            try
            {
                _context.PqrsAttachments.Remove(model);
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

        public async Task<Response> DeletePqrsIdAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.PqrsAttachments.Where(p => p.PqrsId == id).ToListAsync();

            try
            {
                _context.PqrsAttachments.RemoveRange(model);
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

        public async Task<List<PqrsAttachments>> ListAsync(int pqrsId)
        {
            var model = await _context.PqrsAttachments.Where(p => p.PqrsId == pqrsId).ToListAsync();

            return model;
        }
    }
}
