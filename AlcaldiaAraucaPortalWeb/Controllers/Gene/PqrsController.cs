using AlcaldiaAraucaPortalCommon;
using AlcaldiaAraucaPortalReport;
using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo.Pqrs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize(Roles = "Administrador")]
    public class PqrsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsCategoryHelper _pqrsCategoryHelper;
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLineHelper;
        private readonly IWebHostEnvironment _webHost;
        private readonly IStateHelper _stateHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConfiguration _configuration;
        private readonly IPqrsAttachmentsHelper _pqrsAttachments;
        private readonly IPqrsTraceabilityHelper _pqrsTraceabilityHelper;

        public PqrsController(ApplicationDbContext context,
            IPqrsCategoryHelper pqrsCategoryHelper,
            IPqrsStrategicLineHelper pqrsStrategicLineHelper,
            IWebHostEnvironment webHost,
            IStateHelper stateHelper,
            IImageHelper imageHelper,
            IConfiguration configuration,
            IPqrsAttachmentsHelper pqrsAttachments,
            IPqrsTraceabilityHelper pqrsTraceabilityHelper)
        {
            _context = context;
            _pqrsCategoryHelper = pqrsCategoryHelper;
            _pqrsStrategicLineHelper = pqrsStrategicLineHelper;
            _webHost = webHost;
            _stateHelper = stateHelper;
            _imageHelper = imageHelper;
            _configuration = configuration;
            _pqrsAttachments = pqrsAttachments;
            this._pqrsTraceabilityHelper = pqrsTraceabilityHelper;
        }

        // GET: Pqrs
        //[Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Index()
        {
            var UserId = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Id;
            var applicationDbContext = await _context.Pqrs.Include(p => p.ApplicationUser).Include(p => p.PqrsCategory).Include(p => p.State).Where(p => p.UserId == UserId).ToListAsync();
            return View(applicationDbContext.OrderByDescending(p => p.PqrsDate));
        }

        // GET: Pqrs/Details/5
        //[Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.Pqrs
                .Include(p => p.ApplicationUser)
                .Include(p => p.PqrsCategory)
                .Include(p => p.PqrsAttachments)
                .FirstOrDefaultAsync(m => m.PqrsId == id);
            if (pqrs == null)
            {
                return NotFound();
            }

            return View(pqrs);
        }

        // GET: Pqrs/Create
        //[Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Create()
        {
            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName");
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Usuario")]
        public async Task<IActionResult> Create([Bind("PqrsCategoryId,PqrsMessage,PqrsSubject,FileOne,FileTwo,ImgOne,ImgTwo,PqrsStrategicLineId")] PqrsModelsViewGene model)
        {
            if (ModelState.IsValid)
            {
                var userId = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Id;

                var pqrsAttachment = await FileUpload(model.ImgOne, model.ImgTwo, model.FileOne, model.FileTwo);

                var pqrs = new Pqrs
                {
                    PqrsCategoryId = model.PqrsCategoryId,
                    UserId = userId,
                    PqrsDate = DateTime.Now.ToUniversalTime(),
                    PqrsMessage = model.PqrsMessage,
                    StateId = await _stateHelper.StateIdAsync("P", "Abierto"),
                    PqrsSubject = model.PqrsSubject,
                };

                if (pqrsAttachment.Count > 0)
                {
                    pqrs.PqrsAttachments = pqrsAttachment;
                }

                _context.Add(pqrs);

                await _context.SaveChangesAsync();

                var stateId = await _stateHelper.StateIdAsync("G", "Activo");

                var pqrsUserStrategicLineId = _context.PqrsUserStrategicLines.Where(p => p.PqrsStrategicLineId == model.PqrsStrategicLineId && p.StateId == stateId).FirstOrDefault().PqrsUserStrategicLineId;

                var pqrsTrasabilidad = new PqrsTraceability()
                {
                    PqrsId = pqrs.PqrsId,
                    PqrsUserStrategicLineId = pqrsUserStrategicLineId,
                    PqrsTraceabilityDate = DateTime.Now.ToUniversalTime(),
                    Answer = model.PqrsMessage
                };

                _context.Add(pqrsTrasabilidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName", model.PqrsCategoryId);
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName", model.PqrsStrategicLineId);

            return View(model);
        }

        // GET: Pqrs/Edit/5
        //[Authorize(Roles = "Usuario")]
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

            var attachmensts = await _context.PqrsAttachments.Where(a => a.PqrsId == pqrs.PqrsId && a.PqrSend == true).OrderBy(a => a.PqrsAttachmentId).ToListAsync();
            var FileOne = string.Empty;
            var FileTwo = string.Empty;
            var ImgOne = string.Empty;
            var ImgTwo = string.Empty;

            if (attachmensts != null)
            {
                foreach (var item in attachmensts)
                {
                    if (FileOne == "" && item.PqrsAttachmentsPath.Contains(".pdf"))
                    {
                        FileOne = item.PqrsAttachmentsPath;
                    }
                    else if (FileTwo == "" && item.PqrsAttachmentsPath.Contains(".pdf"))
                    {
                        FileTwo = item.PqrsAttachmentsPath;
                    }
                    else if (ImgOne == "" && item.PqrsAttachmentsPath.Contains(".png"))
                    {
                        ImgOne = item.PqrsAttachmentsPath;
                    }
                    else if (ImgTwo == "" && item.PqrsAttachmentsPath.Contains(".png"))
                    {
                        ImgTwo = item.PqrsAttachmentsPath;
                    }
                }
            }

            var model = new PqrsModelsViewGene()
            {
                PqrsId = pqrs.PqrsId,
                PqrsDate = pqrs.PqrsDate,
                UserId = pqrs.UserId,
                StateId = pqrs.StateId,
                PqrsSubject = pqrs.PqrsSubject,
                PqrsMessage = pqrs.PqrsMessage,
                FileOnePath = FileOne,
                FileTwoPath = FileTwo,
                ImgOnePath = ImgOne,
                ImgTwoPath = ImgTwo,
                PqrsCategoryId = pqrs.PqrsCategoryId,
                PqrsStrategicLineId = 1
            };

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FullName", pqrs.UserId);

            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "PqrsCategoryId", "PqrsCategoryName", pqrs.PqrsCategoryId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PqrsModelsViewGene model)
        {
            if (id != model.PqrsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                pqrsAttachmentAsync(model).Wait();

                var pqrs = new Pqrs()
                {
                    PqrsId = model.PqrsId,
                    PqrsDate = model.PqrsDate,
                    StateId = model.StateId,
                    UserId = model.UserId,
                    PqrsCategoryId = model.PqrsCategoryId,
                    PqrsMessage = model.PqrsMessage,
                    PqrsSubject = model.PqrsSubject,
                };

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

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "FullName", model.UserId);

            ViewData["PqrsCategoryId"] = new SelectList(await _pqrsCategoryHelper.ComboAsync(), "CategoryPqrsId", "CategoryPqrsName", model.PqrsCategoryId);

            return View(model);
        }

        // GET: Pqrs/Delete/5
        //[Authorize(Roles = "Usuario")]
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
        //[Authorize(Roles = "Usuario")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqrs = await _context.Pqrs.FindAsync(id);

            var folderImag = _configuration["MyFolders:PqrsImag"];
            var folderFile = _configuration["MyFolders:PqrsFile"];

            var modelImg = await _pqrsAttachments.ListAsync((int)id);

            foreach (var item in modelImg)
            {
                string path = item.PqrsAttachmentsPath.Contains(".png") ? folderImag : folderFile;
                DeleteImage(item.PqrsAttachmentsPath, path);
            }

            _pqrsAttachments.DeletePqrsIdAsync((int)id).Wait();

            _pqrsTraceabilityHelper.DeleteAsync((int)id).Wait();

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
        //[Authorize(Roles = "Publicador")]
        public async Task<IActionResult> IndexAnswer()
        {
            var userPqrs = _context.PqrsUserStrategicLines.Include(p => p.ApplicationUser)
                                                          .Where(p =>
                                                                 p.ApplicationUser.Email == User.Identity.Name &&
                                                                 p.State.StateName.Equals("Activo"))
                                                          .Select(p => new { p.UserId, p.PqrsStrategicLineId }).FirstOrDefault();

            var pqrs = await _context.PqrsTraceabilities.Include(p => p.Pqrs)
                                                        .Where(p => p.PqrsUserStrategicLine.UserId == userPqrs.UserId &&
                                                                    p.PqrsUserStrategicLine.PqrsStrategicLineId == userPqrs.PqrsStrategicLineId &&
                                                                    (p.Pqrs.State.StateName.Equals("Abierto") || p.Pqrs.State.StateName.Equals("En Trámite")) &&
                                                                    p.PqrsUserStrategicLine.State.StateName.Equals("Activo"))
                                                        .Select(p => p.PqrsId)
                                                        .ToListAsync();


            var applicationDbContext = await _context.Pqrs.Include(p => p.ApplicationUser)
                                                          .Include(p => p.PqrsCategory)
                                                          .Include(p => p.State)
                                                          .Where(p => pqrs.Contains(p.PqrsId))
                                                          .ToListAsync();

            return View(applicationDbContext.OrderByDescending(p => p.PqrsDate));
        }

        //[Authorize(Roles = "Publicador")]
        public async Task<IActionResult> Answer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.Pqrs.Include(P => P.ApplicationUser).Include(p => p.PqrsCategory).Where(p => p.PqrsId == id).FirstOrDefaultAsync();

            if (pqrs == null)
            {
                return NotFound();
            }

            var files = await _context.PqrsAttachments.Where(p => p.PqrsId == pqrs.PqrsId).Select(p => new { p.PqrsId, p.PqrsAttachmentsPath }).ToListAsync();


            var model = new PqrsAnswerViewModelGene()
            {
                PqrsId = pqrs.PqrsId,
                FullName = pqrs.ApplicationUser.FullName,
                PqrsCategoryName = pqrs.PqrsCategory.PqrsCategoryName,
                PqrsDate = pqrs.PqrsDate.Date.ToLocalTime(),
                PqrsMessage = pqrs.PqrsMessage,
                PqrsSubject = pqrs.PqrsSubject,
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

                    var TraLast = await (from T in _context.PqrsTraceabilities
                                         where T.PqrsId == model.PqrsId
                                         orderby T.PqrsTraceabilityId descending
                                         select T).FirstOrDefaultAsync();



                    var trasabilidad = new PqrsTraceability
                    {
                        PqrsId = model.PqrsId,
                        PqrsUserStrategicLineId = TraLast.PqrsUserStrategicLineId,
                        PqrsTraceabilityDate = DateTime.Now.ToUniversalTime(),
                        Answer = model.PqrsAnswer
                    };

                    _context.Add(trasabilidad);
                    await _context.SaveChangesAsync();

                    var pqr = _context.Pqrs.Where(p => p.PqrsId == model.PqrsId).FirstOrDefault();
                    pqr.StateId = await _stateHelper.StateIdAsync("P", "Cerrado");

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

        //[Authorize(Roles = "Publicador")]
        public async Task<IActionResult> transfer(int? id)
        {
            var x = await _context.PqrsCategories.ToListAsync();
            return View();
        }

        public IActionResult ReportUser(int id)
        {
            try
            {
                var model = _context.PqrsTraceabilities
                                  .Include(p => p.PqrsUserStrategicLine).ThenInclude(p => p.PqrsStrategicLine)
                                  .Include(p => p.Pqrs).ThenInclude(p => p.PqrsCategory).ThenInclude(p => p.State)
                                  .Where(p => p.PqrsId == id)
                                  .Select(p => new PqrsDetailsViewModel
                                  {
                                      PqrsStrategicLineName = p.PqrsUserStrategicLine.PqrsStrategicLine.PqrsStrategicLineName,
                                      PqrsCategoryName = p.Pqrs.PqrsCategory.PqrsCategoryName,
                                      PqrsSubject = p.Pqrs.PqrsSubject,
                                      StateName = p.Pqrs.State.StateName,
                                      PqrsTraceabilityDate = p.PqrsTraceabilityDate,
                                      Answer = p.Answer
                                  }).ToList();

                var diccionario = new Dictionary<string, object>();

                diccionario.Add("DsPqrs", model.ToDataTable<PqrsDetailsViewModel>());

                ReportService rp = new ReportService();

                var path = "Reports\\Pqrs\\PqrsDetails.rdlc";

                var RpResult = rp.GenerateReportAsync(path, diccionario);

                var stream2 = new MemoryStream(RpResult.MainStream.ToArray());

                return new FileStreamResult(stream2, new MediaTypeHeaderValue("text/plain"))
                {
                    FileDownloadName = "Informe.pdf"
                };

            }
            catch (Exception ex)
            {
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(ex));
            }
        }

        private async Task<string> FileUploadAsync(IFormFile file, string folder, bool ImgFile)
        {
            var response = string.Empty;

            if (ImgFile)
            {
                response = await _imageHelper.UploadImageAsync(file, folder);
            }
            else
            {
                response = await _imageHelper.UploadFileAsync(file, folder);
            }

            return response;
        }

        private async Task<List<PqrsAttachments>> FileUpload(IFormFile ImgOne, IFormFile ImgTwo, IFormFile FileOne, IFormFile FileTwo)
        {
            var pqrsAttachment = new List<PqrsAttachments>();
            var path = string.Empty;
            var folderImag = _configuration["MyFolders:PqrsImag"];
            var folderFile = _configuration["MyFolders:PqrsFile"];
            if (ImgOne != null)
            {
                path = await FileUploadAsync(ImgOne, folderImag, true);
                path = path.Substring(24);
                path = $"~/{path}";
                pqrsAttachment.Add(new PqrsAttachments() { PqrsAttachmentsPath = path, PqrSend = true });
            }
            if (ImgOne != null)
            {
                path = await FileUploadAsync(ImgOne, folderImag, true);
                path = path.Substring(24);
                path = $"~/{path}";
                pqrsAttachment.Add(new PqrsAttachments() { PqrsAttachmentsPath = path, PqrSend = true });
            }
            if (FileOne != null)
            {
                path = await FileUploadAsync(FileOne, folderFile, false);
                path = path.Substring(24);
                path = $"~/{path}";
                pqrsAttachment.Add(new PqrsAttachments() { PqrsAttachmentsPath = path, PqrSend = true });
            }
            if (FileTwo != null)
            {
                path = await FileUploadAsync(FileTwo, folderFile, false);
                path = path.Substring(24);
                path = $"~/{path}";

                pqrsAttachment.Add(new PqrsAttachments() { PqrsAttachmentsPath = path, PqrSend = true });
            }

            return pqrsAttachment;
        }

        private async Task pqrsAttachmentAsync(PqrsModelsViewGene model)
        {
            var path = string.Empty;
            var folderImag = _configuration["MyFolders:PqrsImag"];
            var folderFile = _configuration["MyFolders:PqrsFile"];
            var pqrsAttachment = await _pqrsAttachments.ListAsync(model.PqrsId);


            if (model.ImgOne != null)
            {
                PqrsAttachments modelAttac;

                path = await FileUploadAsync(model.ImgOne, folderImag, true);
                path = path.Substring(24);
                path = $"~/{path}";

                if (model.ImgOnePath == null || model.ImgOnePath == "")
                {
                    modelAttac = new PqrsAttachments() { PqrsId = model.PqrsId, PqrsAttachmentsPath = path, PqrSend = true };
                }
                else
                {
                    modelAttac = pqrsAttachment.Where(p => p.PqrsAttachmentsPath == model.ImgOnePath).FirstOrDefault();
                    modelAttac.PqrsAttachmentsPath = path;
                    DeleteImage(model.ImgOnePath, folderImag);
                }

                _pqrsAttachments.AddUpdateAsync(modelAttac).Wait();
            }
            if (model.ImgTwo != null)
            {
                PqrsAttachments modelAttac;

                path = await FileUploadAsync(model.ImgTwo, folderImag, true);
                path = path.Substring(24);
                path = $"~/{path}";

                if (model.ImgTwoPath == null || model.ImgTwoPath == "")
                {
                    modelAttac = new PqrsAttachments() { PqrsId = model.PqrsId, PqrsAttachmentsPath = path, PqrSend = true };
                }
                else
                {
                    modelAttac = pqrsAttachment.Where(p => p.PqrsAttachmentsPath == model.ImgTwoPath).FirstOrDefault();
                    modelAttac.PqrsAttachmentsPath = path;
                    DeleteImage(model.ImgTwoPath, folderImag);
                }
                _pqrsAttachments.AddUpdateAsync(modelAttac).Wait();
            }

            if (model.FileOne != null)
            {
                PqrsAttachments modelAttac;
                path = await FileUploadAsync(model.FileOne, folderFile, false);
                path = path.Substring(24);
                path = $"~/{path}";

                if (model.FileOnePath == null || model.FileOnePath == "")
                {
                    modelAttac = new PqrsAttachments() { PqrsId = model.PqrsId, PqrsAttachmentsPath = path, PqrSend = true };
                }
                else
                {
                    modelAttac = pqrsAttachment.Where(p => p.PqrsAttachmentsPath == model.FileOnePath).FirstOrDefault();
                    modelAttac.PqrsAttachmentsPath = path;
                    DeleteImage(model.FileOnePath, folderFile);
                }
                _pqrsAttachments.AddUpdateAsync(modelAttac).Wait();
            }
            if (model.FileTwo != null)
            {
                PqrsAttachments modelAttac;

                path = await FileUploadAsync(model.FileTwo, folderFile, false);
                path = path.Substring(24);
                path = $"~/{path}";

                if (model.FileTwoPath == null || model.FileTwoPath == "")
                {
                    modelAttac = new PqrsAttachments() { PqrsId = model.PqrsId, PqrsAttachmentsPath = path, PqrSend = true };
                }
                else
                {
                    modelAttac = pqrsAttachment.Where(p => p.PqrsAttachmentsPath == model.FileTwoPath).FirstOrDefault();
                    modelAttac.PqrsAttachmentsPath = path;
                    DeleteImage(model.FileTwoPath, folderFile);
                }

                _pqrsAttachments.AddUpdateAsync(modelAttac).Wait();
            }
        }

        private string DeleteImage(string file, string folder)
        {
            int start = file.LastIndexOf("/") + 1;

            var file2 = file.Substring(start, file.Length - start);

            file2 = Path.Combine(_webHost.WebRootPath, folder, file2);

            FileInfo fi = new FileInfo(file2);

            if (fi != null)
            {
                System.IO.File.Delete(file2);
                fi.Delete();
            }

            return "Ok";
        }
    }
}
