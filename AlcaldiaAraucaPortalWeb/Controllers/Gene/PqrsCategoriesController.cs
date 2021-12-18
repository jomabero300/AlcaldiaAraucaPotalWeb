using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize(Roles = "Administrador")]

    public class PqrsCategoriesController : Controller
    {
        private readonly IPqrsCategoryHelper _pqrsCategory;
        private readonly IStateHelper _stateHelper;

        public PqrsCategoriesController(IPqrsCategoryHelper pqrsCategory, IStateHelper stateHelper)
        {
            _pqrsCategory = pqrsCategory;
            this._stateHelper = stateHelper;
        }

        // GET: PqrsCategories
        public async Task<IActionResult> Index()
        {
            return View(await _pqrsCategory.ListAsync());
        }

        // GET: PqrsCategories/Create
        public async Task<IActionResult> Create()
        {
            var model = new PqrsCategory()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);
        }

        // POST: PqrsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryPqrsId,CategoryPqrsName,StateId")] PqrsCategory model)
        {
            if (ModelState.IsValid)
            {
                var response = await _pqrsCategory.AddUpdateAsync(model);
                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            return View(model);
        }

        // GET: PqrsCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _pqrsCategory.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        // POST: PqrsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryPqrsId,CategoryPqrsName,StateId")] PqrsCategory model)
        {
            if (id != model.PqrsCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var respose = await _pqrsCategory.AddUpdateAsync(model);
                if(respose.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, respose.Message);
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        // GET: PqrsCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrsCategory = await _pqrsCategory.DeleteAsync((int)id);

            if (pqrsCategory == null)
            {
                return NotFound();
            }

            return View(pqrsCategory);
        }

        // POST: PqrsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _pqrsCategory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
