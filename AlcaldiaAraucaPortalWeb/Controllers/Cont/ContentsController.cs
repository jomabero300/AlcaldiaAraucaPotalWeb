using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Helper;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewCont;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Cont
{
    [Authorize(Roles = "Publicador,Administrador,Prensa")]
    public class ContentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStateHelper _stateHelper;
        private readonly IPqrsUserStrategicLineHelper _userStrategicLineHelper;
        private readonly IPqrsStrategicLineSectorHelper _strategicLineSectorHelper;        
        private readonly IImageHelper _imageHelper;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMailHelper _mailHelper;
        private readonly ISubscriberSectorHelper _subscriberSectorHelper;
        private readonly IContentHelper _contentHelper;
        private readonly IFolderStrategicLineasHelper _folderStrategicLineasHelper;

        public ContentsController(ApplicationDbContext context,
                                  IStateHelper stateHelper,
                                  IPqrsUserStrategicLineHelper userStrategicLineHelper,
                                  IPqrsStrategicLineSectorHelper strategicLineSectorHelper,
                                  IImageHelper imageHelper,
                                  IWebHostEnvironment env,
                                  IConfiguration configuration,
                                  IMailHelper mailHelper,
                                  ISubscriberSectorHelper subscriberSectorHelper,
                                  IContentHelper contentHelper, 
                                  IFolderStrategicLineasHelper folderStrategicLineasHelper)
        {
            _context = context;
            _stateHelper = stateHelper;
            _userStrategicLineHelper = userStrategicLineHelper;
            _strategicLineSectorHelper = strategicLineSectorHelper;
            _imageHelper = imageHelper;
            _env = env;
            _configuration = configuration;
            _mailHelper = mailHelper;
            _subscriberSectorHelper = subscriberSectorHelper;
            _contentHelper = contentHelper;
            _folderStrategicLineasHelper=folderStrategicLineasHelper;
        }

        // GET: Contents
        public async Task<IActionResult> Index()
        {
            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();

            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            var applicationDbContext = _context.Contents
                                        .Include(c => c.ApplicationUser)
                                        .Include(c => c.PqrsStrategicLineSector)
                                        .Include(c => c.State)
                                        .Where(c => c.UserId == userId.Id && 
                                                    c.PqrsStrategicLineSector.PqrsStrategicLineId == strategiaLineaId.PqrsStrategicLineId)
                                        .OrderByDescending(x => x.ContentId);
            if(strategiaLineaId==null)
            {
                return NotFound();
            }
            
            ViewBag.LineName = strategiaLineaId.PqrsStrategicLineName;

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();
            var content = await _context.Contents
                .Include(c => c.ApplicationUser)
                .Include(c => c.PqrsStrategicLineSector)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.ContentId == id && m.UserId == userId.Id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // GET: Contents/Create
        public async Task<IActionResult> Create()
        {
            var model = new ContentModelsViewCont
            {
                ContentDetails = new List<ContentDetailModelsViewCont>()
            };

            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();

            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            ViewBag.LineName = await _folderStrategicLineasHelper.lpineName(User.Identity.Name);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContentModelsViewCont model)
        {

            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                model.ContentTitle = Utilities.StartCharacterToUpper(model.ContentTitle);

                model.ContentText = Utilities.StartCharacterToUpper(model.ContentText);
                
                if(model.ContentText.Contains("http"))
                {
                    model.ContentText = FilesHelper.ConvertToTextInLik(model.ContentText);
                }

                string folder = await _folderStrategicLineasHelper.FolderPath(model.PqrsStrategicLineSectorId,User.Identity.Name);

                var path = string.Empty;

                if (model.ContentUrlImg != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ContentUrlImg, folder);
                }

                int stateId = await _stateHelper.StateIdAsync("G", "Previo");

                for (int i = 0; i < model.ContentDetails.Count; i++)
                {
                    if (model.ContentDetails[i].isEsta == 1)
                    {
                        model.ContentDetails[i].ContentUrlImg =_folderStrategicLineasHelper.FileMove(model.ContentDetails[i].ContentUrlImg, folder);
                    }
                    else
                    {
                        model.ContentDetails[i].ContentUrlImg = model.ContentDetails[i].ContentUrlImg;
                    }

                    if(model.ContentDetails[i].ContentText.Contains("http"))
                    {
                        model.ContentDetails[i].ContentText = FilesHelper.ConvertToTextInLik(model.ContentDetails[i].ContentText);
                    }
                }

                var modelAdd = new Content()
                {
                    PqrsStrategicLineSectorId = model.PqrsStrategicLineSectorId,
                    UserId = userId.Id,
                    ContentDate = DateTime.Now,
                    ContentTitle = model.ContentTitle,
                    ContentText = model.ContentText,
                    ContentUrlImg = path,
                    StateId = stateId,
                    ContentDetails = model.ContentDetails.Select(c => new ContentDetail()
                    {
                        ContentDate = DateTime.Now,
                        ContentTitle = c.ContentTitle,
                        ContentText = c.ContentText,
                        ContentUrlImg = c.ContentUrlImg,
                        StateId = stateId
                    }).ToList()
                };

                List<SubscriberSector> subscriberSector = await _subscriberSectorHelper.BySectorIdAsync(model.PqrsStrategicLineSectorId);

                _context.Add(modelAdd);

                await _context.SaveChangesAsync();
                
                if(subscriberSector!=null)
                {
                    _context.SubscriberSectors.UpdateRange(subscriberSector);
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction(nameof(Index));
            }


            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName", model.PqrsStrategicLineSectorId);

            return View(model);
        }
        // GET: Contents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content content = await _context.Contents.Include(c => c.ContentDetails).Include(b => b.PqrsStrategicLineSector).Where(q => q.ContentId == id).FirstOrDefaultAsync();

            if (content == null)
            {
                return NotFound();
            }

            ContentEditViewModel model = new ContentEditViewModel() {
                ContentId=content.ContentId,
                UserId = content.UserId,
                ContentDate = content.ContentDate,
                StateId = content.StateId,
                PqrsStrategicLineSectorId=content.PqrsStrategicLineSectorId,
                ContentTitle = content.ContentTitle,
                ContentText = content.ContentText,
                ContentUrlImg1 = content.ContentUrlImg,
                ContentDetails=content.ContentDetails,                
            };


            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();

            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            ViewBag.LineName = await _folderStrategicLineasHelper.lpineName(User.Identity.Name);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContentEditViewModel model)
        {
            if (id != model.ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var folder = await _folderStrategicLineasHelper.FolderPath(model.PqrsStrategicLineSectorId,User.Identity.Name);

                    var path = string.Empty;

                    if (model.ContentUrlImg != null)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ContentUrlImg, folder);
                    }

                    Content content=new Content() {
                        ContentId=model.ContentId,
                        UserId = model.UserId,
                        ContentDate = model.ContentDate,
                        StateId = model.StateId,
                        PqrsStrategicLineSectorId=model.PqrsStrategicLineSectorId,
                        ContentTitle = model.ContentTitle,
                        ContentText = model.ContentText,
                        ContentUrlImg = (model.ContentUrlImg != null? path : model.ContentUrlImg1)
                    };

                    _context.Update(content);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este registro");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();

            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName", model.PqrsStrategicLineSectorId);

            return View(model);
        }

        // GET: Contents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Contents
                .Include(c => c.ApplicationUser)
                .Include(c => c.PqrsStrategicLineSector).ThenInclude(c => c.PqrsStrategicLine)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.ContentId == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //TODO: Eliminar las imagenes

            var content = await _context.Contents.FindAsync(id);

            try
            {
                var contentDetalle = await _context.ContentDetails.Where(c => c.ContentId == id).ToListAsync();

                _context.ContentDetails.RemoveRange(contentDetalle);

                await _context.SaveChangesAsync();

                _context.Contents.Remove(content);

                await _context.SaveChangesAsync();

                var folder = await _folderStrategicLineasHelper.FolderPath(content.PqrsStrategicLineSectorId,User.Identity.Name);

                var responsE = await _imageHelper.DeleteImageAsync(content.ContentUrlImg, folder);

                if (contentDetalle.Count > 0)
                {
                    foreach (var item in contentDetalle)
                    {
                        var respons = await _imageHelper.DeleteImageAsync(item.ContentUrlImg, folder);
                    }
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDetails(int id)
        {

            try
            {
                ContentDetail model = await _contentHelper.DetailsIdAsync(id);
                Content content = await _contentHelper.ByIdAsync(model.ContentId);

                var response = await _contentHelper.DeleteDetailsAsync(id);

                //TODO: Eliminar las imagenes
                if(response.Succeeded)
                {
                    string folder = await _folderStrategicLineasHelper.FolderPath(content.PqrsStrategicLineSectorId,User.Identity.Name);

                    string responsE = await _imageHelper.DeleteImageAsync(model.ContentUrlImg, folder);
                }
                return Json(new { status = true });
            }
            catch (System.Exception ex)
            {
                string ltmensaje = string.Empty;
                if (ex.InnerException.Message.Contains("IX_"))
                {
                    ltmensaje = "El registro ya existe..";
                }
                else if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    ltmensaje = "El registro no se puede eliminar porque tiene registros relacionados";
                }
                else
                {
                    ltmensaje = ex.Message;
                }

                return Json(new { status = false, message = ltmensaje });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddContentDetalle(int id, string Title, string ContentText, IFormFile file,string fileUrl)
        {
            //TODO: Agregar las imagenes
            Content lineaSector = await _contentHelper.ByIdAsync(id);
            string response = string.Empty;
            response = fileUrl;

            if (Title.Contains("http"))
            {
                Title = FilesHelper.ConvertToTextInLik(Title);
            }
            if (ContentText.Contains("http"))
            {
                ContentText = FilesHelper.ConvertToTextInLik(ContentText);
            }

            if (file!=null)
            {
                string folder = await _folderStrategicLineasHelper.FolderPath(lineaSector.PqrsStrategicLineSectorId,User.Identity.Name);
                response = await _imageHelper.UploadImageAsync(file, folder);
            }

            var detalle = new ContentDetail
            {
                ContentId = id,
                ContentTitle = Title,
                ContentText = ContentText,
                ContentUrlImg = response,
                ContentDate = DateTime.Now,
                StateId = 1
            };

            try
            {
                _context.ContentDetails.Add(detalle);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este registro");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Json(new { status = true });
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateContentDetalle(int id, string Title, string ContentText,IFormFile file, string fileUrl, int idDetail, string UrlImgOld,DateTime ContentDetailDate)
        {
            Content lineaSector = await _contentHelper.ByIdAsync(id);
            var linea = await _strategicLineSectorHelper.ByIdAsync(lineaSector.PqrsStrategicLineSectorId);

            string response = string.Empty;

            response = !string.IsNullOrWhiteSpace(fileUrl)? fileUrl: UrlImgOld;

            if (Title.Contains("http"))
            {
                Title = FilesHelper.ConvertToTextInLik(Title);
            }
            if (ContentText.Contains("http"))
            {
                ContentText = FilesHelper.ConvertToTextInLik(ContentText);
            }

            string folder = await _folderStrategicLineasHelper.FolderPath(linea.PqrsStrategicLineId, lineaSector.PqrsStrategicLineSectorId);

            if (file!=null)
            {
                response = await _imageHelper.UploadImageAsync(file, folder);
            }
            if(response != UrlImgOld)
            {
                await _imageHelper.DeleteImageAsync(UrlImgOld, folder);
            }

            var detalle = new ContentDetail
            {
                ContentId = id,
                ContentDetailsId = idDetail,
                ContentTitle = Title,
                ContentText = ContentText,
                ContentUrlImg = response,
                ContentDate = ContentDetailDate,
                StateId = 1
            };

            try
            {
                _context.ContentDetails.Update(detalle);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe este registro");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Json(new { status = true });

        }


        [HttpPost]
        public async Task<IActionResult> UploadeTemp(IFormFile file)
        {
            var folder = _configuration["MyFolders:Content"];

            string response = await _imageHelper.UploadImageAsync(file, folder);

            return Json(new { path = response });
        }

        [HttpPost]
        public IActionResult DeleteTemp(string file)
        {
            var folder = _configuration["MyFolders:Content"];

            int start = file.LastIndexOf("/") + 1;

            var file2 = file.Substring(start, file.Length - start);

            file2 = Path.Combine(_env.WebRootPath, folder, file2);

            FileInfo fi = new FileInfo(file2);
            if (fi != null)
            {
                System.IO.File.Delete(file2);
                fi.Delete();
            }

            return Json(new { path = "Ok" });
        }

        [HttpPost]
        public IActionResult GetUrl(int lValo)
        {
            var Url = _configuration["MyDomain:Url"];

            return Json(new { Url = Url });
        }

    }
}