using AlcaldiaAraucaPortalWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        public async Task<IActionResult> Details(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var rol = await _context.Roles.FirstOrDefaultAsync(r => r.Id == Id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }


        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var rol = await _context.Roles.FirstOrDefaultAsync(r => r.Id == Id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

    }
}
