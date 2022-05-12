using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize]
    public class GroupProductivesController : Controller
    {
        private readonly IGroupProductiveHelper _groupProductive;
        private readonly IStateHelper _stateHelper;

        public GroupProductivesController(IGroupProductiveHelper groupProductive, IStateHelper stateHelper)
        {
            _groupProductive = groupProductive;
            _stateHelper = stateHelper;
        }

        // GET: GroupProductives
        public async Task<IActionResult> Index()
        {
            var module = await _groupProductive.ListAsync();

            return View(module);
        }

        // GET: GroupProductives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupProductive = await _groupProductive.ByIdAsync((int)id);

            if (groupProductive == null)
            {
                return NotFound();
            }

            return View(groupProductive);
        }

        // GET: GroupProductives/Create
        public async Task<IActionResult> Create()
        {
            var model = new GroupProductive()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);
        }

        // POST: GroupProductives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupProductiveId,GroupProductiveName,StateId")] GroupProductive model)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _groupProductive.AddUpdateAsync(model);

                if (reponse.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, reponse.Message);
            }

            return View(model);
        }

        // GET: GroupProductives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupProductive = await _groupProductive.ByIdAsync((int)id);

            if (groupProductive == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", groupProductive.StateId);

            return View(groupProductive);
        }

        // POST: GroupProductives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupProductiveId,GroupProductiveName,StateId")] GroupProductive model)
        {
            if (id != model.GroupProductiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _groupProductive.AddUpdateAsync(model);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        // GET: GroupProductives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupProductive = await _groupProductive.ByIdAsync((int)id);

            if (groupProductive == null)
            {
                return NotFound();
            }

            return View(groupProductive);
        }

        // POST: GroupProductives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _groupProductive.DeleteAsync(id);
            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.Message);

            return View(response);
        }
    }
}
