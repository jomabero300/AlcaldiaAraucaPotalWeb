using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICommuneTownshipHelper _communeTownship;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalk;

        public ApplicationUsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ICommuneTownshipHelper communeTownship,
            INeighborhoodSidewalkHelper neighborhoodSidewalk)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _communeTownship = communeTownship;
            _neighborhoodSidewalk = neighborhoodSidewalk;
        }
        public IActionResult Index()
        {
            var user = (from U in _context.ApplicationUsers
                       join E in _context.UserRoles on U.Id equals E.UserId
                       join R in _context.Roles on E.RoleId equals R.Id
                       select new { U.Id, U.FullName, R.Name }).ToList();

            var users = user.Select(u => new RoleUserModelView()
            {
                UserId=u.Id,
                FullName=u.FullName,
                RoleId=u.Name
            });

            return View(users.OrderBy(u=>u.FullName));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =await (from U in _context.ApplicationUsers
                        join E in _context.UserRoles on U.Id equals E.UserId
                        join R in _context.Roles on E.RoleId equals R.Id
                        where  U.Id==id
                        select new { U.Id, U.FullName, R.Name }).FirstOrDefaultAsync();

            var users =new RoleUserModelView()
            {
                UserId = user.Id,
                FullName = user.FullName,
                RoleId = user.Name
            };

            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqrs = await _context.ApplicationUsers.FindAsync(id);

            if (pqrs == null)
            {
                return NotFound();
            }

            var uder = new RoleUserModelView()
            {
                FullName = pqrs.FullName,
                UserId = pqrs.Id
            };

            var roleId = _context.UserRoles.Where(u => u.UserId == pqrs.Id).FirstOrDefault().RoleId;

            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", roleId);

            return View(uder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,FullName,RoleId")] RoleUserModelView model)
        {
            if (id != model.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                    
                    var user = await _userManager.FindByIdAsync(model.UserId);
                    var role = _context.UserRoles.Where(u => u.UserId == model.UserId).FirstOrDefault();
                    var roleName = _context.Roles.Where(r => r.Id == role.RoleId).FirstOrDefault().Name;
                    await _userManager.RemoveFromRoleAsync(user, roleName);

                    roleName = _context.Roles.Where(r => r.Id == model.RoleId).FirstOrDefault().Name;
                    await _userManager.AddToRoleAsync(user, roleName);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name",model.RoleId);

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = (from U in _context.ApplicationUsers
                              join E in _context.UserRoles on U.Id equals E.UserId
                              join R in _context.Roles on E.RoleId equals R.Id
                              where U.Id == id
                              select new { U.Id, U.FullName, R.Name }).FirstOrDefault();

            var users = new RoleUserModelView()
            {
                UserId = user.Id,
                FullName = user.FullName,
                RoleId = user.Name
            };

            return View(users);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var state = await _context.Users.FindAsync(id);
            _context.Users.Remove(state);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CommuneTownshipSearch(int ZoneId)
        {
            var lista = await _communeTownship.ComboAsync(ZoneId);

            return Json(lista);
        }

        [HttpPost]
        public async Task<IActionResult> NeighborhoodSidewalkSearch(int CommuneTownshipId)
        {
            var lista = await _neighborhoodSidewalk.ComboAsync(CommuneTownshipId);

            return Json(lista);
        }
    }
}
