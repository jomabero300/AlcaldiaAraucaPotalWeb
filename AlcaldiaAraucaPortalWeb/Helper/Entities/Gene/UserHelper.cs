using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewGene;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public UserHelper(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }
        public async Task<List<ApplicationUser>> UsersComboAsync()
        {
            var model1 = from u in _context.ApplicationUsers
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.Roles on ur.RoleId equals r.Id
                        where r.Name.Equals("Publicador") select u.Id;

            var model = await _context.ApplicationUsers.Where(a=>model1.Contains(a.Id)).ToListAsync();

            model.Add(new ApplicationUser { Id = "", LastName = "[Seleccione un usuario..]" });

            return model.OrderBy(m => m.FullName).ToList();
        }

        public IdentityUser UserByIdEmailAsync(string email)
        {
            var model = _context.Users.FirstOrDefault(u=>u.Email==email);

            return model;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<List<UsersViewModel>> UsersRoleComboAsync(string IdRole)
        {
            var users = string.IsNullOrEmpty(IdRole) ?
                                from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                orderby u.FirstName, u.LastName
                                select new { u.FirstName,u.LastName, u.Email, u.Address, u.Document, u.DocumentType.DocumentTypeName, u.Gender.GenderName, }:
                                from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where r.Id == IdRole
                                orderby u.FirstName, u.LastName
                                select new { u.FirstName, u.LastName, u.Email, u.Address, u.Document, u.DocumentType.DocumentTypeName, u.Gender.GenderName, };
            List<UsersViewModel> rpt =await users.Select(u => new UsersViewModel()
            {
                Address=u.Address,
                Document=u.Document,
                DocumentTypeName=u.DocumentTypeName,
                Email=u.Email,
                FirstName=u.FirstName,
                LastName=u.LastName,
                GenderName=u.GenderName
            }).ToListAsync();

            return rpt;
        }
    }
}
