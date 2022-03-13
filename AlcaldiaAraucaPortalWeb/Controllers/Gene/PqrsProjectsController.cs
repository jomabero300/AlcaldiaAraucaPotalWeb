using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize(Roles = "Usuario")]
    public class PqrsProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLineHelper;
        private readonly IPqrsProjectActivitieHelper _projectActivitieHelper;

        public PqrsProjectsController(
            ApplicationDbContext context, 
            IPqrsStrategicLineHelper pqrsStrategicLineHelper,
            IPqrsProjectActivitieHelper projectActivitieHelper)
        {
            _context = context;
            this._pqrsStrategicLineHelper = pqrsStrategicLineHelper;
            this._projectActivitieHelper = projectActivitieHelper;
        }

        // GET: PqrsProjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PqrsProjects.Include(p => p.ApplicationUser).Include(p=>p.State);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PqrsProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsProject = await _context.PqrsProjects
                .Include(p => p.PqrsProjectActivities)
                .Include(p => p.PqrsProjectProponents)
                .Include(p=>p.State)
                .FirstOrDefaultAsync(m => m.PqrsProjectId == id);
            if (pqrsProject == null)
            {
                return NotFound();
            }

            return View(pqrsProject);
        }

        // GET: PqrsProjects/Create
        public async Task<IActionResult> Create()
        {
            var model = new PqrsProjectViewModelsGene
            {
                UserId = "436dd7c3-047f-484c-8320-f32b5eab3cg5",
                RegistrationDate = DateTime.Now,
                StateId=1
            };

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            return View(model);
        }

        // POST: PqrsProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PqrsProjectViewModelsGene model)
        {
            if (ModelState.IsValid)
            {
                var stateId =await _context.States.Where(s => s.StateName.Equals("Abierto")).FirstOrDefaultAsync();
                model.UserId = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
                model.StateId = stateId.StateId;
                
                var r = new Random();
                var pqrsUserStrategicLine = await _context.PqrsUserStrategicLines.Where(p => p.PqrsStrategicLineId == model.PqrsStrategicLineId).Select(p => p.PqrsUserStrategicLineId).ToListAsync();
                var indece = r.Next(0, pqrsUserStrategicLine.Count());

                var pqrsUserStrategicLineId = pqrsUserStrategicLine.ElementAt(indece);

                var traceabiliti = new PqrsProjectTraceability()
                {
                    PqrsUserStrategicLineId= pqrsUserStrategicLineId,
                    PqrsTraceabilityDate=DateTime.Now,
                    Answer=model.Name,
                };

                var modelProject = new PqrsProject()
                {
                    UserId=model.UserId,
                    RegistrationDate=DateTime.Now,
                    Name=model.Name,
                    Object=model.Object,
                    StateId=stateId.StateId,
                    PqrsProjectLocated="",
                    PqrsProjectActivities=model.PqrsProjectActivities.Select(a=>new PqrsProjectActivitie() { Budget=a.Budget,Description=a.Description,DateEnd=a.DateEnd,DateStart=a.DateStart}).ToList(),
                    PqrsProjectProponents=model.PqrsProjectProponents.Select(p=>new PqrsProjectProponent() { Email=p.Email,Name=p.Name,Phone=p.Phone}).ToList()
                };

                _context.Add(modelProject);
                try
                {
                    await _context.SaveChangesAsync();

                    traceabiliti.PqrsProjectId = modelProject.PqrsProjectId;

                    _context.Add(traceabiliti);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este proyecto.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            return View(model);
        }

        // GET: PqrsProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsProject0 = await _context.PqrsProjects.Include(p => p.PqrsProjectActivities).Include(p => p.PqrsProjectProponents).Where(p => p.PqrsProjectId == id).FirstOrDefaultAsync();

            if (pqrsProject0 == null)
            {
                return NotFound();
            }
            var pqrsProjectId = await _context.PqrsProjectTraceabilities.Include(p => p.PqrsUserStrategicLine).Where(p => p.PqrsProjectId == pqrsProject0.PqrsProjectId).FirstOrDefaultAsync();

            var model = new PqrsProjectViewModelsGene()
            {
                PqrsProjectId= pqrsProject0.PqrsProjectId,
                PqrsStrategicLineId= pqrsProjectId.PqrsUserStrategicLine.PqrsStrategicLineId,
                UserId= pqrsProject0.UserId,
                RegistrationDate= pqrsProject0.RegistrationDate,
                Name= pqrsProject0.Name,
                Object= pqrsProject0.Object,
                PqrsProjectLocated= pqrsProject0.PqrsProjectLocated,
                StateId= pqrsProject0.StateId,
                PqrsProjectActivities= pqrsProject0.PqrsProjectActivities.Select(r=>new PqrsProjectActivitie() { PqrsProjectActivitieId=r.PqrsProjectActivitieId,PqrsProjectId=r.PqrsProjectId,Description=r.Description,Budget=r.Budget,DateStart=r.DateStart, DateEnd=r.DateEnd }).ToList(),
                PqrsProjectProponents= pqrsProject0.PqrsProjectProponents.Select(r=>new PqrsProjectProponent() { PqrsProponentId=r.PqrsProponentId,PqrsProjectId=r.PqrsProjectId, Email=r.Email,Name=r.Name,Phone=r.Phone}).ToList()
            };

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineUserComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName", pqrsProjectId.PqrsUserStrategicLine.PqrsStrategicLineId);

            return View(model);
        }

        // POST: PqrsProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsProjectId,UserId,RegistrationDate,Name,Object")] PqrsProject pqrsProject)
        {
            if (id != pqrsProject.PqrsProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqrsProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", pqrsProject.UserId);
            return View(pqrsProject);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqrsProject = await _context.PqrsProjects.FindAsync(id);

            var pqrsProjectActivitie = await _context.PqrsProjectActivities.Where(p => p.PqrsProjectId == id).ToListAsync();
            
            var pqrsProponents = await _context.PqrsProponents.Where(p => p.PqrsProjectId == id).ToListAsync();

            var pqrsTracibilities = await _context.PqrsProjectTraceabilities.Where(t => t.PqrsProjectId == id).ToListAsync();
            
            try
            {
                
                _context.PqrsProjectActivities.RemoveRange(pqrsProjectActivitie);
                
                _context.SaveChanges();
                
                _context.PqrsProponents.RemoveRange(pqrsProponents);
                
                _context.SaveChanges();

                _context.PqrsProjectTraceabilities.RemoveRange(pqrsTracibilities);

                _context.SaveChanges();
                
                _context.PqrsProjects.Remove(pqrsProject);
                
                _context.SaveChanges();

                return Json(new { status = true });

            }
            catch (Exception ex)
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
        public async Task<IActionResult> PqrsProjectActivityEditAdd(PqrsProjectActivitie model)
        {

            var response = await _projectActivitieHelper.AddUpdateAsync(model);
            if (response.Succeeded)
            {
                return Json(new { pqrsProjectId = model.PqrsProjectId });
            }

            return Json(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PqrsProjectActivityAdd(int id, PqrsProjectActivitie model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(model);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Edit),new { id=model.PqrsProjectId});

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este proyecto.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }

        [HttpPost, ActionName("PqrsProjectActivityDelete")]
        public async Task<IActionResult> PqrsProjectActivityDeleteConfirmed(int id)
        {
            var pqrsProject = await _context.PqrsProjectActivities.FindAsync(id);
            try
            {
                _context.PqrsProjectActivities.Remove(pqrsProject);

                _context.SaveChanges();

                return Json(new { status = true });

            }
            catch (Exception ex)
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

                return Json(new { status = false, message = ltmensaje, PqrsProjectId = pqrsProject.PqrsProjectId });
            }
        }
    }
}
