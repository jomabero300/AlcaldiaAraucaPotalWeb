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
    public class DocumentTypeHelper : IDocumentTypeHelper
    {
        private readonly ApplicationDbContext _context;
        public DocumentTypeHelper(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Response> AddUpdateAsync(DocumentType model)
        {
            if (model.DocumentTypeId == 0)
            {
                _context.DocumentTypes.Add(model);
            }
            else
            {
                _context.DocumentTypes.Update(model);
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
        public async Task<DocumentType> ByIdAsync(int id)
        {
            var model = await _context.DocumentTypes.FirstOrDefaultAsync(a => a.DocumentTypeId== id);

            return model;
        }
        public async Task<List<DocumentType>> ComboAsync()
        {
            List<DocumentType> model = await _context.DocumentTypes.ToListAsync();

            model.Add(new DocumentType { DocumentTypeId = 0, DocumentTypeName = "[Seleccione un documento..]" });

            return model.OrderBy(m => m.DocumentTypeName).ToList();
        }
        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.DocumentTypes.Where(a => a.DocumentTypeId == id).FirstOrDefaultAsync();

            try
            {
                _context.DocumentTypes.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response = DBHelper.ExceptionCatcha(ex);
            }

            return response;
        }
        public async Task<List<DocumentType>> ListAsync()
        {
            var model = await _context.DocumentTypes.ToListAsync();

            return model.OrderBy(m => m.DocumentTypeName).ToList();
        }
    }
}
