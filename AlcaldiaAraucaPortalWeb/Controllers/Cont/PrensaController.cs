using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Helper;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Susc;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewCont;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Cont
{
    [Authorize(Roles = "Prensa,Administrador")]

    public class PrensaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsStrategicLineHelper _strategicLineHelper;
        private readonly IPqrsStrategicLineSectorHelper _strategicLineSectorHelper;
        private readonly IFolderStrategicLineasHelper _folderStrategicLineasHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IStateHelper _stateHelper;
        private readonly ISubscriberSectorHelper _subscriberSectorHelper;
        private readonly IPqrsUserStrategicLineHelper _userStrategicLineHelper;


        public PrensaController(ApplicationDbContext context,
            IPqrsStrategicLineHelper strategicLineHelper,
            IPqrsStrategicLineSectorHelper strategicLineSectorHelper,
            IFolderStrategicLineasHelper folderStrategicLineasHelper,
            IImageHelper imageHelper,
            IStateHelper stateHelper,
            ISubscriberSectorHelper subscriberSectorHelper,
            IPqrsUserStrategicLineHelper userStrategicLineHelper)
        {
            _context=context;
            _strategicLineHelper=strategicLineHelper;
            _strategicLineSectorHelper=strategicLineSectorHelper;
            _folderStrategicLineasHelper=folderStrategicLineasHelper;
            _imageHelper=imageHelper;
            _stateHelper=stateHelper;
            _subscriberSectorHelper=subscriberSectorHelper;
            _userStrategicLineHelper=userStrategicLineHelper;
        }

        public IActionResult IndexPrueba()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Contents
                                        .Include(c => c.ApplicationUser)
                                        .Include(c => c.PqrsStrategicLineSector)
                                        .Include(c => c.State)
                                        .Where(c => c.State.StateName=="Previo")
                                        .OrderByDescending(x => x.ContentId);

            ViewBag.LineName ="Prensa";

            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewData["PqrsStrategicLineId"] = new SelectList(await _strategicLineHelper.PqrsStrategicLineComboPrenAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(0), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            ContentModelsViewContPren model = new ContentModelsViewContPren
            {
                ContentDetails = new List<ContentDetailModelsViewCont>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContentModelsViewContPren model)
        {
            var userId = await _context.ApplicationUsers.Where(c => c.Email == User.Identity.Name).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                model.ContentTitle = Utilities.StartCharacterToUpper(model.ContentTitle);

                model.ContentText = Utilities.StartCharacterToUpper(model.ContentText);

                if (model.ContentText.Contains("http"))
                {
                    model.ContentText = FilesHelper.ConvertToTextInLik(model.ContentText);
                }

                //string folder = await _folderStrategicLineasHelper.FolderPath(model.PqrsStrategicLineSectorId, User.Identity.Name);
                string folder = await _folderStrategicLineasHelper.FolderPath(model.PqrsStrategicLineId, model.PqrsStrategicLineSectorId);

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

                    if (model.ContentDetails[i].ContentText.Contains("http"))
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

                if (subscriberSector!=null)
                {
                    _context.SubscriberSectors.UpdateRange(subscriberSector);
                    await _context.SaveChangesAsync();
                }

                //TODO: Applicate to update database

                return RedirectToAction(nameof(Index));
            }


            var strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(userId.Id);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName", model.PqrsStrategicLineSectorId);

            return View(model);
        }

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

            ContentEditViewModel model = new ContentEditViewModel()
            {
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


            PqrsStrategicLineSector strategiaLineaId = await _strategicLineSectorHelper.ByIdAsync(content.PqrsStrategicLineSectorId);

            PqrsStrategicLine strategicLine = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(strategiaLineaId.PqrsStrategicLineId);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            List<State> estados = (await _stateHelper.StateComboAsync("G")).Where(s => s.StateName.Equals("Activo") || s.StateName.Equals("Previo")).ToList();

            estados.Where(s => s.StateName.Equals("Activo")).Select(s => { s.StateName="Publicar"; return s.StateName; }).ToList();

            ViewData["StateId"] = new SelectList(estados, "StateId", "StateName");

            ViewBag.LineName = strategicLine.PqrsStrategicLineName;

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

                    PqrsStrategicLineSector pqrsStrategicLine = await _strategicLineSectorHelper.ByIdAsync(model.PqrsStrategicLineSectorId);

                    string folder = await _folderStrategicLineasHelper.FolderPath(pqrsStrategicLine.PqrsStrategicLineId, model.PqrsStrategicLineSectorId);

                    var path = string.Empty;

                    if (model.ContentUrlImg != null)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ContentUrlImg, folder);
                    }

                    Content content = new Content()
                    {
                        ContentId=model.ContentId,
                        UserId = model.UserId,
                        ContentDate = model.ContentDate,
                        StateId = model.StateId,
                        PqrsStrategicLineSectorId=model.PqrsStrategicLineSectorId,
                        ContentTitle = model.ContentTitle,
                        ContentText = model.ContentText,
                        ContentUrlImg = (model.ContentUrlImg != null ? path : model.ContentUrlImg1)
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

            PqrsStrategicLineSector strategiaLineaId = await _strategicLineSectorHelper.ByIdAsync(model.PqrsStrategicLineSectorId);

            PqrsStrategicLine strategicLine = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(strategiaLineaId.PqrsStrategicLineId);

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineSectorHelper.ComboAsync(strategiaLineaId.PqrsStrategicLineId), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName",model.PqrsStrategicLineSectorId);


            List<State> estados = (await _stateHelper.StateComboAsync("G")).Where(s => s.StateName.Equals("Activo") || s.StateName.Equals("Previo")).ToList();

            estados.Where(s => s.StateName.Equals("Activo")).Select(s => { s.StateName="Publicar"; return s.StateName; }).ToList();

            ViewData["StateId"] = new SelectList(estados, "StateId", "StateName");


            return View(model);
        }

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

                PqrsStrategicLineSector strategiaLineaId = await _strategicLineSectorHelper.ByIdAsync(content.PqrsStrategicLineSectorId);


                var folder = await _folderStrategicLineasHelper.FolderPath(strategiaLineaId.PqrsStrategicLineId, content.PqrsStrategicLineSectorId);

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

        public async Task<JsonResult> getSector(int Id)
        {
            var strategicLine=await _strategicLineSectorHelper.ComboAsync(Id);

            return Json(strategicLine);
        }
    }
}
