using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class PqrsUserStrategicLinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLineHelper;
        private readonly IUserHelper _userHelper;
        private readonly IStateHelper _stateHelper;
        private readonly IPqrsUserStrategicLineHelper _pqrsUserStrategicLineHelper;

        private static readonly string[] lv = { "Activo", "Inactivo" };

        public PqrsUserStrategicLinesController(ApplicationDbContext context,
            IPqrsStrategicLineHelper pqrsStrategicLineHelper,
            IUserHelper userHelper,
            IStateHelper stateHelper,
            IPqrsUserStrategicLineHelper pqrsUserStrategicLineHelper)
        {
            _context = context;
            _pqrsStrategicLineHelper = pqrsStrategicLineHelper;
            _userHelper = userHelper;
            _stateHelper = stateHelper;
            _pqrsUserStrategicLineHelper = pqrsUserStrategicLineHelper;
        }

        // GET: PqrsUserStrategicLines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PqrsUserStrategicLines
                                               .Include(p => p.ApplicationUser)
                                               .Include(p => p.PqrsStrategicLine)
                                               .Include(p => p.State);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PqrsUserStrategicLines/Create
        public async Task<IActionResult> Create()
        {

            ViewData["UserId"] = new SelectList(await _userHelper.UsersComboAsync(), "Id", "FullNameWithDocument");
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            int stateId = await _stateHelper.StateIdAsync("G", "Activo");

            var line = new PqrsUserStrategicLine { StateId = stateId };

            return View(line);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PqrsUserStrategicLineId,UserId,PqrsStrategicLineId,StateId")] PqrsUserStrategicLine model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateAsync("G", lv), "StateId", "StateName", model.StateId);

            ViewData["UserId"] = new SelectList(await _userHelper.UsersComboAsync(), "Id", "FullNameWithDocument", model.UserId);

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName", model.PqrsStrategicLineId);

            return View(model);
        }

        // GET: PqrsUserStrategicLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsUserStrategicLine = await _context.PqrsUserStrategicLines.FindAsync(id);

            if (pqrsUserStrategicLine == null)
            {
                return NotFound();
            }

            string[] lv = { "Activo", "Inactivo" };
            ViewData["StateId"] = new SelectList(await _stateHelper.StateAsync("G", lv), "StateId", "StateName", pqrsUserStrategicLine.StateId);

            ViewData["UserId"] = new SelectList(await _userHelper.UsersComboAsync(), "Id", "FullNameWithDocument", pqrsUserStrategicLine.UserId);

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsUserStrategicLineHelper.PqrsStrategicLineIdAsync(pqrsUserStrategicLine.UserId), "PqrsStrategicLineId", "PqrsStrategicLineName", pqrsUserStrategicLine.PqrsStrategicLineId);


            return View(pqrsUserStrategicLine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsUserStrategicLineId,UserId,PqrsStrategicLineId,StateId")] PqrsUserStrategicLine model)
        {
            if (id != model.PqrsUserStrategicLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateAsync("G", lv), "StateId", "StateName", model.StateId);

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", model.UserId);

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsUserStrategicLineHelper.PqrsStrategicLineIdAsync(model.UserId), "PqrsStrategicLineId", "PqrsStrategicLineName", model.PqrsStrategicLineId);

            return View(model);
        }

        // GET: PqrsUserStrategicLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsUserStrategicLine = await _context.PqrsUserStrategicLines
                .Include(p => p.ApplicationUser)
                .Include(p => p.PqrsStrategicLine)
                .FirstOrDefaultAsync(m => m.PqrsUserStrategicLineId == id);
            if (pqrsUserStrategicLine == null)
            {
                return NotFound();
            }

            return View(pqrsUserStrategicLine);
        }

        // POST: PqrsUserStrategicLines/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var pqrsUserStrategicLine = await _context.PqrsUserStrategicLines.FindAsync(id);
                //Validar si tiene registros y colocarlo en estado eliminado
                var estadoB = from p in _context.PqrsUserStrategicLines
                              from t in _context.PqrsTraceabilities
                              where
                                   p.PqrsUserStrategicLineId == t.PqrsUserStrategicLineId &&
                                   p.PqrsUserStrategicLineId == id
                              select p;
                if (estadoB.Count() > 0)
                {
                    pqrsUserStrategicLine.StateId = await _stateHelper.StateIdAsync("G", "Inactivo");

                    _context.Update(pqrsUserStrategicLine);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.PqrsUserStrategicLines.Remove(pqrsUserStrategicLine);
                    await _context.SaveChangesAsync();
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

        [HttpGet]
        public async Task<IActionResult> LineaAtrategicSearch(string userId)
        {
            var lista = await _pqrsUserStrategicLineHelper.PqrsStrategicLineIdAsync(userId);

            return Json(lista);
        }
    }
}
