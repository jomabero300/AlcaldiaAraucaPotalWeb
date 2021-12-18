using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class PqrsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsCategoryHelper _pqrsCategoryHelper;
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLineHelper;
        private readonly IWebHostEnvironment _webHost;
        private readonly IStateHelper _stateHelper;

        public PqrsController(ApplicationDbContext context, 
            IPqrsCategoryHelper pqrsCategoryHelper,
            IPqrsStrategicLineHelper pqrsStrategicLineHelper,
            IWebHostEnvironment webHost,
            IStateHelper stateHelper)
        {
            _context = context;
            _pqrsCategoryHelper = pqrsCategoryHelper;
            _pqrsStrategicLineHelper = pqrsStrategicLineHelper;
            _webHost = webHost;
            _stateHelper = stateHelper;
        }

        // GET: Pqrs
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Index()
        {
            var UserId = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Id;
            var applicationDbContext = await _context.Pqrs.Include(p => p.ApplicationUser).Include(p => p.PqrsCategory).Include(p=>p.State).Where(p => p.UserId == UserId).ToListAsync();
            return View(applicationDbContext.OrderByDescending(p => p.PqrsDate));
        }

        // GET: Pqrs/Details/5
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.Pqrs
                .Include(p => p.ApplicationUser)
                .Include(p => p.PqrsCategory)
                .Include(p=>p.PqrsAttachments)
                .FirstOrDefaultAsync(m => m.PqrsId == id);
            if (pqrs == null)
            {
                return NotFound();
            }

            return View(pqrs);
        }

        // GET: Pqrs/Create
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Create()
        {
            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName");
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Create([Bind("PqrsCategoryId,PqrsMessage,FileOne,FileTwo,ImgOne,ImgTwo,PqrsStrategicLineId")] PqrsModelsViewGene model)
        {
            if (ModelState.IsValid)
            {
                var userId = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Id;
                var pqrs = new Pqrs
                {
                    PqrsCategoryId = model.PqrsCategoryId,
                    UserId = userId,
                    PqrsDate = DateTime.Now,
                    PqrsMessage = model.PqrsMessage,
                    StateId =await _stateHelper.StateIdAsync("P", "Abierto")
                };

                _context.Add(pqrs);
                await _context.SaveChangesAsync();

                int lncontPdf = 0;
                int lncontImg = 0;

                var ltRoute = $"{pqrs.PqrsId}-{lncontPdf}.pdf";

                List<PqrsAttachments> pqrsAttachment=new List<PqrsAttachments>();

                if (model.FileOne != null)
                {
                    ltRoute = FilesHelper.GetUploadedFileName(model.FileOne, "Files\\Pqrs\\pdf", ltRoute, _webHost);
                    pqrsAttachment.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                    //_context.PqrsAttachments.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                    lncontPdf++;
                    ltRoute = $"{pqrs.PqrsId}-{lncontPdf}.pdf";
                }


                if (model.FileTwo != null)
                {
                    ltRoute = FilesHelper.GetUploadedFileName(model.FileTwo, "Files\\Pqrs\\pdf", ltRoute, _webHost);
                    pqrsAttachment.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                    //_context.PqrsAttachments.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                }

                ltRoute = $"{pqrs.PqrsId}-{lncontImg}.png";

                if (model.ImgOne != null)
                {
                    ltRoute = FilesHelper.GetUploadedFileName(model.ImgOne, "Files\\Pqrs\\Img", ltRoute, _webHost);
                    pqrsAttachment.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                    //_context.PqrsAttachments.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                    lncontImg++;
                    ltRoute = $"{pqrs.PqrsId}-{lncontImg}.png";
                }

                if (model.ImgTwo != null)
                {
                    ltRoute = FilesHelper.GetUploadedFileName(model.ImgTwo, "Files\\Pqrs\\Img", ltRoute, _webHost);
                    //_context.PqrsAttachments.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                    pqrsAttachment.Add(new PqrsAttachments() { PqrsId = pqrs.PqrsId, PqrsAttachmentsPath = ltRoute, PqrSend = true });
                }

                _context.AddRange(pqrsAttachment);
                await _context.SaveChangesAsync();

                var stateId = await _stateHelper.StateIdAsync("G", "Activo");

                var pqrsUserStrategicLineId = _context.PqrsUserStrategicLines.Where(p => p.PqrsStrategicLineId == model.PqrsStrategicLineId && p.StateId== stateId).FirstOrDefault().PqrsUserStrategicLineId;

                var pqrsTrasabilidad = new PqrsTraceability()
                {
                    PqrsId=pqrs.PqrsId,
                    PqrsUserStrategicLineId= pqrsUserStrategicLineId,
                    PqrsTraceabilityDate=DateTime.Now,
                    Answer =model.PqrsMessage
                };

                _context.Add(pqrsTrasabilidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName", model.PqrsCategoryId);
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName",model.PqrsStrategicLineId);

            return View(model);
        }

        // GET: Pqrs/Edit/5
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.Pqrs.FindAsync(id);
            if (pqrs == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FullName", pqrs.UserId);
            
            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName", pqrs.PqrsCategoryId);

            return View(pqrs);
        }

        [Authorize(Roles = "Usuario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsId,PqrsCategoryId,UserId,PqrsDate,PqrsMessage,StateId")] Pqrs pqrs)
        {
            if (id != pqrs.PqrsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqrs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FullName", pqrs.UserId);

            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "CategoryPqrsId", "CategoryPqrsName", pqrs.PqrsCategoryId);

            return View(pqrs);
        }

        // GET: Pqrs/Delete/5
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.Pqrs
                .Include(p => p.ApplicationUser)
                .Include(p => p.PqrsCategory)
                .FirstOrDefaultAsync(m => m.PqrsId == id);
            if (pqrs == null)
            {
                return NotFound();
            }

            return View(pqrs);
        }

        // POST: Pqrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Usuario")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqrs = await _context.Pqrs.FindAsync(id);
            _context.Pqrs.Remove(pqrs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PDFViewerNewTab(string fileName)
        {
            fileName = fileName.Substring(1);
            fileName = fileName.Replace('/', '\\');
            string path = _webHost.WebRootPath + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }

        // GET: Pqrs
        [Authorize(Roles = "Publicador")]
        public async Task<IActionResult> IndexAnswer()
        {
            var userPqrs = _context.PqrsUserStrategicLines.Include(p => p.ApplicationUser)
                                                          .Where( p => 
                                                                  p.ApplicationUser.Email == User.Identity.Name && 
                                                                  p.State.StateName.Equals("Activo"))
                                                          .Select(p => new { p.UserId, p.PqrsStrategicLineId }).FirstOrDefault();

            var pqrs = await _context.PqrsTraceabilities.Include(p => p.Pqrs)
                                                                        .Where(p => p.PqrsUserStrategicLine.UserId == userPqrs.UserId && 
                                                                               p.PqrsUserStrategicLine.PqrsStrategicLineId == userPqrs.PqrsStrategicLineId &&
                                                                               (p.Pqrs.State.StateName.Equals("Abierto") || p.Pqrs.State.StateName.Equals("En Trámite")) &&
                                                                               p.PqrsUserStrategicLine.State.StateName.Equals("Activo"))
                                                                        .Select(p=>p.PqrsId)
                                                                        .ToListAsync();


            var applicationDbContext = await _context.Pqrs.Include(p => p.ApplicationUser)
                                                          .Include(p => p.PqrsCategory)
                                                          .Include(p=>p.State)
                                                          .Where(p => pqrs.Contains(p.PqrsId))
                                                          .ToListAsync();

            return View(applicationDbContext.OrderByDescending(p => p.PqrsDate));
        }
        
        [Authorize(Roles = "Publicador")]
        public async Task<IActionResult> Answer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.Pqrs.Include(P=>P.ApplicationUser).Include(p=>p.PqrsCategory).Where(p=>p.PqrsId==id).FirstOrDefaultAsync();

            if (pqrs == null)
            {
                return NotFound();
            }

            var files = await _context.PqrsAttachments.Where(p => p.PqrsId == pqrs.PqrsId).Select(p => new { p.PqrsId, p.PqrsAttachmentsPath }).ToListAsync();


            var model = new PqrsAnswerViewModelGene()
            {
                PqrsId=pqrs.PqrsId,
                FullName=pqrs.ApplicationUser.FullName,
                PqrsCategoryName=pqrs.PqrsCategory.PqrsCategoryName,
                PqrsDate=pqrs.PqrsDate,
                PqrsMessage=pqrs.PqrsMessage,
                Files = files.Select(f => new PqrsAnswerFileViewModelGene()
                {
                    PqrsId = f.PqrsId,
                    PqrsAttachmentsPath = f.PqrsAttachmentsPath
                }).ToList()
            };

           

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(int id, PqrsAnswerViewModelGene model)
        {
            if (id != model.PqrsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var TraLast =await (from T in _context.PqrsTraceabilities
                                   where T.PqrsId == model.PqrsId
                                   orderby T.PqrsTraceabilityId descending
                                   select T).FirstOrDefaultAsync();



                    var trasabilidad = new PqrsTraceability
                    {
                        PqrsId=model.PqrsId,
                        PqrsUserStrategicLineId=TraLast.PqrsUserStrategicLineId,
                        PqrsTraceabilityDate=DateTime.Now,
                        Answer=model.PqrsAnswer
                    };

                    _context.Add(trasabilidad);
                    await _context.SaveChangesAsync();

                    var pqr = _context.Pqrs.Where(p => p.PqrsId == model.PqrsId).FirstOrDefault();
                    pqr.StateId =await _stateHelper.StateIdAsync("P", "Cerrado");

                    _context.Update(pqr);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(IndexAnswer));
            }

            return View(model);
        }

        [Authorize(Roles = "Publicador")]
        public async Task<IActionResult> transfer(int? id)
        {
            var x = await _context.PqrsCategories.ToListAsync();
            return View();
        }

    }
}
