using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Proc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Proc
{
    [Authorize]
    public class GroupCommunitiesController : Controller
    {
        private readonly IGroupCommunityHelper _groupCommnuty;
        private readonly IStateHelper _stateHelper;

        public GroupCommunitiesController(IGroupCommunityHelper groupCommnuty,IStateHelper stateHelper)
        {
            _groupCommnuty = groupCommnuty;
            this._stateHelper = stateHelper;
        }

        // GET: GroupCommunities
        public async Task<IActionResult> Index()
        {
            return View(await _groupCommnuty.ListAsync());
        }

        // GET: GroupCommunities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _groupCommnuty.ByIdAsync((int)id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: GroupCommunities/Create
        public async Task<IActionResult> Create()
        {
            var model = new GroupCommunity() {
                StateId =await _stateHelper.StateIdAsync("G", "Activo")
            };
            return View(model);
        }


        // POST: GroupCommunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupCommunityId,GroupCommunityName,StateId")] GroupCommunity model)
        {
            if (ModelState.IsValid)
            {
                var response = await _groupCommnuty.AddUpdateAsync(model);
                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            return View(model);
        }

        // GET: GroupCommunities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _groupCommnuty.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        // POST: GroupCommunities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupCommunityId,GroupCommunityName,StateId")] GroupCommunity model)
        {
            if (id != model.GroupCommunityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var responde = await _groupCommnuty.AddUpdateAsync(model);
                
                if (responde.Succeeded)
                { 
                    return RedirectToAction(nameof(Index)); 
                }

                ModelState.AddModelError(string.Empty, responde.Message);
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        // GET: GroupCommunities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _groupCommnuty.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: GroupCommunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _groupCommnuty.DeleteAsync(id);

            if(response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            var model = await _groupCommnuty.ByIdAsync(id);
            ModelState.AddModelError(string.Empty, response.Message);

            return View(model);
        }
    }
}
