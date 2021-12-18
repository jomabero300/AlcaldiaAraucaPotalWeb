using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize(Roles = "Administrador")]

    public class PqrsStrategicLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PqrsStrategicLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PqrsStrategicLines
        public async Task<IActionResult> Index()
        {
            return View(await _context.PqrsStrategicLines.ToListAsync());
        }

        // GET: PqrsStrategicLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsStrategicLine = await _context.PqrsStrategicLines
                .FirstOrDefaultAsync(m => m.PqrsStrategicLineId == id);
            if (pqrsStrategicLine == null)
            {
                return NotFound();
            }

            return View(pqrsStrategicLine);
        }

        // GET: PqrsStrategicLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PqrsStrategicLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PqrsStrategicLineId,PqrsStrategicLineName")] PqrsStrategicLine pqrsStrategicLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pqrsStrategicLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pqrsStrategicLine);
        }

        // GET: PqrsStrategicLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsStrategicLine = await _context.PqrsStrategicLines.FindAsync(id);
            if (pqrsStrategicLine == null)
            {
                return NotFound();
            }
            return View(pqrsStrategicLine);
        }

        // POST: PqrsStrategicLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsStrategicLineId,PqrsStrategicLineName")] PqrsStrategicLine pqrsStrategicLine)
        {
            if (id != pqrsStrategicLine.PqrsStrategicLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqrsStrategicLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PqrsStrategicLineExists(pqrsStrategicLine.PqrsStrategicLineId))
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
            return View(pqrsStrategicLine);
        }

        // GET: PqrsStrategicLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsStrategicLine = await _context.PqrsStrategicLines
                .FirstOrDefaultAsync(m => m.PqrsStrategicLineId == id);
            if (pqrsStrategicLine == null)
            {
                return NotFound();
            }

            return View(pqrsStrategicLine);
        }

        // POST: PqrsStrategicLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqrsStrategicLine = await _context.PqrsStrategicLines.FindAsync(id);
            _context.PqrsStrategicLines.Remove(pqrsStrategicLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PqrsStrategicLineExists(int id)
        {
            return _context.PqrsStrategicLines.Any(e => e.PqrsStrategicLineId == id);
        }
    }
}
