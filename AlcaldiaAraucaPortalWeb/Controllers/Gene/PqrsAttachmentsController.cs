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

    public class PqrsAttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PqrsAttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PqrsAttachments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PqrsAttachments.Include(p => p.Pqrs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PqrsAttachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsAttachments = await _context.PqrsAttachments
                .Include(p => p.Pqrs)
                .FirstOrDefaultAsync(m => m.PqrsAttachmentId == id);
            if (pqrsAttachments == null)
            {
                return NotFound();
            }

            return View(pqrsAttachments);
        }

        // GET: PqrsAttachments/Create
        public IActionResult Create()
        {
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage");
            return View();
        }

        // POST: PqrsAttachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PqrsAttachmentId,PqrsId,PqrsAttachmentsPath,PqrSend")] PqrsAttachments pqrsAttachments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pqrsAttachments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage", pqrsAttachments.PqrsId);
            return View(pqrsAttachments);
        }

        // GET: PqrsAttachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsAttachments = await _context.PqrsAttachments.FindAsync(id);
            if (pqrsAttachments == null)
            {
                return NotFound();
            }
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage", pqrsAttachments.PqrsId);
            return View(pqrsAttachments);
        }

        // POST: PqrsAttachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsAttachmentId,PqrsId,PqrsAttachmentsPath,PqrSend")] PqrsAttachments pqrsAttachments)
        {
            if (id != pqrsAttachments.PqrsAttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqrsAttachments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PqrsAttachmentsExists(pqrsAttachments.PqrsAttachmentId))
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
            ViewData["PqrsId"] = new SelectList(_context.Pqrs, "PqrsId", "PqrsMessage", pqrsAttachments.PqrsId);
            return View(pqrsAttachments);
        }

        // GET: PqrsAttachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsAttachments = await _context.PqrsAttachments
                .Include(p => p.Pqrs)
                .FirstOrDefaultAsync(m => m.PqrsAttachmentId == id);
            if (pqrsAttachments == null)
            {
                return NotFound();
            }

            return View(pqrsAttachments);
        }

        // POST: PqrsAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqrsAttachments = await _context.PqrsAttachments.FindAsync(id);
            _context.PqrsAttachments.Remove(pqrsAttachments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PqrsAttachmentsExists(int id)
        {
            return _context.PqrsAttachments.Any(e => e.PqrsAttachmentId == id);
        }
    }
}
