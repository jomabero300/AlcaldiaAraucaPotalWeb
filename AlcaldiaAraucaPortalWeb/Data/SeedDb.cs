using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb.Data
{
    public class SeedDb
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                //                context.Database.EnsureCreated();

                if (!context.Genders.Any())
                {
                    context.Genders.AddRange(
                        new Gender() { GenderName = "Hombre" },
                        new Gender() { GenderName = "Mujer" },
                        new Gender() { GenderName = "Otro" });
                    context.SaveChanges();
                }
                if (!context.DocumentTypes.Any())
                {
                    context.DocumentTypes.AddRange(
                        new DocumentType() { DocumentTypeName = "Cédula de ciudadanía" },
                        new DocumentType() { DocumentTypeName = "Cédula de extranjería" }
                    );

                    context.SaveChanges();
                }
            }

        }

        public static async Task Seed(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Datos iniciales

            if (!context.Genders.Any())
            {
                context.Genders.AddRange(
                    new Gender() { GenderName = "Hombre" },
                    new Gender() { GenderName = "Mujer" },
                    new Gender() { GenderName = "Otro" });

                context.SaveChanges();
            }

            if (!context.DocumentTypes.Any())
            {
                context.DocumentTypes.AddRange(
                    new DocumentType() { DocumentTypeName = "Cédula de ciudadanía" },
                    new DocumentType() { DocumentTypeName = "Cédula de extranjería" });

                context.SaveChanges();
            }

            if (!context.States.Any())
            {
                context.States.AddRange(
                    new State() { StateName = "Activo", StateB = true, StateType = "G" },
                    new State() { StateName = "Inactivo", StateB = true, StateType = "G" },
                    new State() { StateName = "Suspendido", StateB = true, StateType = "G" },
                    new State() { StateName = "Eliminado", StateB = true, StateType = "G" },
                    new State() { StateName = "Abierto", StateB = true, StateType = "P" },
                    new State() { StateName = "En Trámite", StateB = true, StateType = "P" },
                    new State() { StateName = "Cerrado", StateB = true, StateType = "P" });

                context.SaveChanges();
            }

            if (!context.PqrsCategories.Any())
            {
                context.PqrsCategories.AddRange(
                    new PqrsCategory() { PqrsCategoryName = "Peticiones", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Quejas", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "Reclamos", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryName = "solicitudes", StateId = 1 });

                context.SaveChanges();
            }

            if (!context.PqrsStrategicLines.Any())
            {
                context.PqrsStrategicLines.AddRange(
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Desarrollo social incluyente" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Crecimiento económico" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Arauca verde, ordenada y sostenible" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Infraestructura social y productiva" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Buen gobierno" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Seguridad convivencia y justicia" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Gestión del conocimiento" });

                context.SaveChanges();
            }

            //Crear roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrador", "Publicador","Usuario" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Create user
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var documentTypeId = context.DocumentTypes.Where(d => d.DocumentTypeName.Equals("Cédula de ciudadanía")).FirstOrDefault().DocumentTypeId;
            var genderId = context.Genders.Where(d => d.GenderName.Equals("Hombre")).FirstOrDefault().GenderId;

            if (userManager.FindByEmailAsync("jomabero300@gmail.com").Result==null)
            {
                var user = new ApplicationUser
                {
                    UserName= "jomabero300@gmail.com",
                    Email = "jomabero300@gmail.com",
                    NormalizedEmail = "JOMABERO300@GMAIL.COM",
                    NormalizedUserName = "JOMABERO300@GMAIL.COM",
                    EmailConfirmed=true,
                    LockoutEnabled=true,

                    Document = "123456789",
                    DocumentTypeId = documentTypeId,
                    FirstName = "José Manuel",
                    LastName = "Bello Romero",
                    BirdDarte = DateTime.Parse("25/10/1972"),
                    GenderId = genderId,

                    PhoneNumber = "1234567890",
                };

                IdentityResult result = userManager.CreateAsync(user, "Mbel123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrador").Wait();
                }
            }
            var emailAdmi = "admin@gmail.com";
            if (userManager.FindByEmailAsync(emailAdmi).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = emailAdmi,
                    Email = emailAdmi,
                    NormalizedEmail = emailAdmi,
                    NormalizedUserName = emailAdmi,
                    EmailConfirmed = true,
                    LockoutEnabled = true,

                    Document = "123456789",
                    DocumentTypeId = documentTypeId,
                    FirstName = "Super",
                    LastName = "Administrador",
                    BirdDarte = DateTime.Parse("25/10/1972"),
                    GenderId = genderId,

                    PhoneNumber = "1234567890",
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrador").Wait();
                }
            }

        }
    }
}
