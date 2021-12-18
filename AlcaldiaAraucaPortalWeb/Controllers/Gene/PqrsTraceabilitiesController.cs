using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize(Roles = "Administrador")]

    public class PqrsTraceabilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PqrsTraceabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PqrsTraceabilities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PqrsTraceabilities.Include(p => p.Pqrs).Include(p => p.PqrsUserStrategicLine).Include(p => p.PqrsUserStrategicLine);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PqrsTraceabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsTraceability = await _context.PqrsTraceabilities
                .Include(p => p.Pqrs)
                .Include(p => p.PqrsUserStrategicLine)
                .Include(p => p.PqrsUserStrategicLine)
                .FirstOrDefaultAsync(m => m.PqrsTraceabilityId == id);
            if (pqrsTraceability == null)
            {
                return NotFound();
            }

            return View(pqrsTraceability);
        }

        // GET: PqrsTraceabilities/Create
        public IActionResult Create()
        {
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage");
            ViewData["PqrsStrategicLineId"] = new SelectList(_context.PqrsStrategicLines, "PqrsStrategicLineId", "PqrsStrategicLineName");
            ViewData["PqrsUserStrategicLineId"] = new SelectList(_context.PqrsUserStrategicLines, "PqrsUserStrategicLineId", "UserId");
            return View();
        }

        // POST: PqrsTraceabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PqrsTraceabilityId,PqrsId,PqrsUserStrategicLineId,PqrsTraceabilityDate,Answer")] PqrsTraceability pqrsTraceability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pqrsTraceability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage", pqrsTraceability.PqrsId);
            //ViewData["PqrsStrategicLineId"] = new SelectList(_context.PqrsStrategicLines, "PqrsStrategicLineId", "PqrsStrategicLineName", pqrsTraceability.PqrsStrategicLineId);
            ViewData["PqrsUserStrategicLineId"] = new SelectList(_context.PqrsUserStrategicLines, "PqrsUserStrategicLineId", "UserId", pqrsTraceability.PqrsUserStrategicLineId);
            return View(pqrsTraceability);
        }

        // GET: PqrsTraceabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsTraceability = await _context.PqrsTraceabilities.FindAsync(id);
            if (pqrsTraceability == null)
            {
                return NotFound();
            }
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage", pqrsTraceability.PqrsId);
            ViewData["PqrsStrategicLineId"] = new SelectList(_context.PqrsStrategicLines, "PqrsStrategicLineId", "PqrsStrategicLineName", pqrsTraceability.PqrsUserStrategicLine.PqrsStrategicLineId);
            ViewData["PqrsUserStrategicLineId"] = new SelectList(_context.PqrsUserStrategicLines, "PqrsUserStrategicLineId", "UserId", pqrsTraceability.PqrsUserStrategicLineId);
            return View(pqrsTraceability);
        }

        // POST: PqrsTraceabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsTraceabilityId,PqrsId,PqrsUserStrategicLineId,PqrsTraceabilityDate,PqrsStrategicLineId,Answer")] PqrsTraceability pqrsTraceability)
        {
            if (id != pqrsTraceability.PqrsTraceabilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqrsTraceability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PqrsTraceabilityExists(pqrsTraceability.PqrsTraceabilityId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage", pqrsTraceability.PqrsId);
            ViewData["PqrsStrategicLineId"] = new SelectList(_context.PqrsStrategicLines, "PqrsStrategicLineId", "PqrsStrategicLineName", pqrsTraceability.PqrsUserStrategicLine.PqrsStrategicLineId);
            ViewData["PqrsUserStrategicLineId"] = new SelectList(_context.PqrsUserStrategicLines, "PqrsUserStrategicLineId", "UserId", pqrsTraceability.PqrsUserStrategicLineId);
            return View(pqrsTraceability);
        }

        // GET: PqrsTraceabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsTraceability = await _context.PqrsTraceabilities
                .Include(p => p.Pqrs)
                .Include(p => p.PqrsUserStrategicLine.PqrsStrategicLine)
                .Include(p => p.PqrsUserStrategicLine)
                .FirstOrDefaultAsync(m => m.PqrsTraceabilityId == id);

            if (pqrsTraceability == null)
            {
                return NotFound();
            }

            return View(pqrsTraceability);
        }

        // POST: PqrsTraceabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqrsTraceability = await _context.PqrsTraceabilities.FindAsync(id);
            _context.PqrsTraceabilities.Remove(pqrsTraceability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PqrsTraceabilityExists(int id)
        {
            return _context.PqrsTraceabilities.Any(e => e.PqrsTraceabilityId == id);
        }
    }
}
