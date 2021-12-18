using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class SocialNetworksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStateHelper _stateHelper;

        public SocialNetworksController(ApplicationDbContext context,IStateHelper stateHelper)
        {
            _context = context;
            _stateHelper = stateHelper;
        }

        // GET: SocialNetworks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialNetwork.ToListAsync());
        }

        // GET: SocialNetworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialNetwork = await _context.SocialNetwork
                .FirstOrDefaultAsync(m => m.SocialNetworkId == id);
            if (socialNetwork == null)
            {
                return NotFound();
            }

            return View(socialNetwork);
        }

        // GET: SocialNetworks/Create
        public async Task<IActionResult> Create()
        {
            var model = new SocialNetwork()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);
        }

        // POST: SocialNetworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocialNetworkId,SocialNetworkName,StateId")] SocialNetwork socialNetwork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialNetwork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialNetwork);
        }

        // GET: SocialNetworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialNetwork = await _context.SocialNetwork.FindAsync(id);
            if (socialNetwork == null)
            {
                return NotFound();
            }
            return View(socialNetwork);
        }

        // POST: SocialNetworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialNetworkId,SocialNetworkName")] SocialNetwork socialNetwork)
        {
            if (id != socialNetwork.SocialNetworkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialNetwork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialNetworkExists(socialNetwork.SocialNetworkId))
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
            return View(socialNetwork);
        }

        // GET: SocialNetworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialNetwork = await _context.SocialNetwork
                .FirstOrDefaultAsync(m => m.SocialNetworkId == id);
            if (socialNetwork == null)
            {
                return NotFound();
            }

            return View(socialNetwork);
        }

        // POST: SocialNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialNetwork = await _context.SocialNetwork.FindAsync(id);
            _context.SocialNetwork.Remove(socialNetwork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialNetworkExists(int id)
        {
            return _context.SocialNetwork.Any(e => e.SocialNetworkId == id);
        }
    }
}
