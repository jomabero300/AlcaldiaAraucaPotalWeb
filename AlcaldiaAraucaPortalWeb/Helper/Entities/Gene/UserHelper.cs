using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Gene
{
    public class UserHelper : IUserHelper
    {
        private readonly ApplicationDbContext _context;

        public UserHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ApplicationUser>> UsersComboAsync()
        {
            var model1 = from u in _context.ApplicationUsers
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where r.Name.Equals("Publicador") select u.Id;

            var model = await _context.ApplicationUsers.Where(a=>model1.Contains(a.Id)).ToListAsync();

            model.Add(new ApplicationUser { Id = "", LastName = "[Seleccione un genero..]" });

            return model.OrderBy(m => m.FullName).ToList();
        }

        public IdentityUser UserByIdEmailAsync(string email)
        {
            var model = _context.Users.FirstOrDefault(u=>u.Email==email);

            return model;
        }
    }
}
