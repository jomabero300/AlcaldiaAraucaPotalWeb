using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class ProfessionsController : Controller
    {
        private readonly IProfessionHelper _professionHelper;
        private readonly IStateHelper _stateHelper;

        public ProfessionsController(IProfessionHelper professionHelper, IStateHelper stateHelper)
        {
            _professionHelper = professionHelper;
            _stateHelper = stateHelper;
        }

        // GET: Professions
        public async Task<IActionResult> Index()
        {
            return View(await _professionHelper.ListAsync());
        }

        // GET: Professions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _professionHelper.ByIdAsync((int)id);

            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        // GET: Professions/Create
        public async Task<IActionResult> Create()
        {
            var model = new Profession()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessionId,ProfessionName,StateId")] Profession model)
        {
            if (ModelState.IsValid)
            {
                var response = await _professionHelper.AddUpdateAsync(model);

                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            return View(model);
        }

        // GET: Professions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _professionHelper.ByIdAsync((int)id);

            if (profession == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", profession.StateId);

            return View(profession);
        }

        // POST: Professions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessionId,ProfessionName,StateId")] Profession model)
        {
            if (id != model.ProfessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _professionHelper.AddUpdateAsync(model);
                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        // GET: Professions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _professionHelper.ByIdAsync((int)id);

            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respose = await _professionHelper.DeleteAsync((int)id);
            if(respose.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, respose.Message);
            var model = await _professionHelper.ByIdAsync((int)id);
            return View(model);
        }
    }
}
