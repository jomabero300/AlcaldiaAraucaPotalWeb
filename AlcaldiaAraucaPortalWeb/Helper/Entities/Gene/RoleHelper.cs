using AlcaldiaAraucaPortalWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class RoleHelper : IRoleHelper
    {
        private readonly ApplicationDbContext _context;

        public RoleHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<IdentityRole>> ComboAsync()
        {
            var roles = await _context.Roles.ToListAsync();

            roles.Add(new IdentityRole { Id = "", Name = "[Todos los roles..]" });

            return roles.OrderBy(r=>r.Name).ToList();
        }
    }
}
