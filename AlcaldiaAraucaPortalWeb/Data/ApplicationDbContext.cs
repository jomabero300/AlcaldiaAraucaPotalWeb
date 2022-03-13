using AlcaldiaAraucaPortalWeb.Data.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Data.Entities.Proc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Data.Entities.Susc;

namespace AlcaldiaAraucaPortalWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.HasDefaultSchema("Admi");

            builder
                .Entity<DocumentType>()
                .HasIndex(g => g.DocumentTypeName)
                .IsUnique()
                .HasDatabaseName("IX_DocumentType_Name");

            builder
                .Entity<Gender>()
                .HasIndex(g => g.GenderName)
                .IsUnique()
                .HasDatabaseName("IX_Gender_Name");

            builder
                .Entity<Department>()
                .HasIndex(g => g.DepartmentName)
                .IsUnique()
                .HasDatabaseName("IX_Department_Name");

            builder
                .Entity<Municipality>()
                .HasIndex(g => new { g.DepartmentId,g.MunicipalityName })
                .IsUnique()
                .HasDatabaseName("IX_Department_Municipality_Name");

            builder
                .Entity<Zone>()
                .HasIndex(g =>g.ZoneName)
                .IsUnique()
                .HasDatabaseName("IX_Zone_Name");

            builder.Entity<PqrsStrategicLine>()
                .HasIndex(c => c.PqrsStrategicLineName)
                .IsUnique()
                .HasDatabaseName("IX_PqrsStrategicLine_Name");

            builder.Entity<PqrsStrategicLineSector>()
                .HasIndex(c => new {c.PqrsStrategicLineId, c.PqrsStrategicLineSectorName })
                .IsUnique()
                .HasDatabaseName("IX_PqrsStrategicLineSector_Name");

            builder.Entity<PqrsCategory>()
                .HasIndex(c => c.PqrsCategoryName)
                .IsUnique()
                .HasDatabaseName("IX_PqrsCategory_Name");

            builder.Entity<State>()
                .HasIndex(c => new { c.StateName, c.StateType })
                .IsUnique()
                .HasDatabaseName("IX_State_Name");

            builder.Entity<Department>()
                .HasIndex(c => c.DepartmentName)
                .IsUnique()
                .HasDatabaseName("IX_Department_Name");

            builder.Entity<Municipality>()
                .HasIndex(c => new { c.DepartmentId,c.MunicipalityName })
                .IsUnique()
                .HasDatabaseName("IX_Municipality_Name");

            builder.Entity<CommuneTownship>()
                .HasIndex(c => new { c.MunicipalityId ,c.ZoneId,c.CommuneTownshipName })
                .IsUnique()
                .HasDatabaseName("IX_CommuneTownship_Name");

            builder.Entity<NeighborhoodSidewalk>()
                .HasIndex(c => new { c.CommuneTownshipId,c.NeighborhoodSidewalkName })
                .IsUnique()
                .HasDatabaseName("IX_NeighborhoodSidewalk_Name");


            builder.Entity<Profession>()
                .HasIndex(c => c.ProfessionName)
                .IsUnique()
                .HasDatabaseName("IX_Profession_Name");

            builder.Entity<SocialNetwork>()
                .HasIndex(c => c.SocialNetworkName)
                .IsUnique()
                .HasDatabaseName("IX_SocialNetwork_Name");

            builder.Entity<GroupProductive>()
                .HasIndex(c => c.GroupProductiveName)
                .IsUnique()
                .HasDatabaseName("IX_GroupProductive_Name");

            builder.Entity<GroupCommunity>()
                .HasIndex(c => c.GroupCommunityName)
                .IsUnique()
                .HasDatabaseName("IX_GroupCommunity_Name");

            builder.Entity<Affiliate>()
                .HasCheckConstraint("ck_Affiliate_TypeUserId", "TypeUserId='P' OR TypeUserId='E'");



            builder.Entity<AffiliateGroupCommunity>()
                .HasIndex(c => new { c.AffiliateId, c.GroupCommunityId })
                .IsUnique()
                .HasDatabaseName("IX_AffiliateGroupCommunity_AffiliateGroupCommunity");

            builder.Entity<AffiliateProfession>()
                .HasIndex(c => new { c.AffiliateId, c.AffiliateProfessionId })
                .IsUnique()
                .HasDatabaseName("IX_AffiliateProfession_AffiliateProfession");

            builder.Entity<AffiliateSocialNetwork>()
                .HasIndex(c => new { c.AffiliateId, c.AffiliateSocialNetworkId})
                .IsUnique()
                .HasDatabaseName("IX_AffiliateSocialNetwork_AffiliateSocialNetwork");

            builder.Entity<AffiliateGroupProductive>()
                .HasIndex(c => new { c.AffiliateId, c.AffiliateGroupProductiveId})
                .IsUnique()
                .HasDatabaseName("IX_AffiliateGroupProductive_AffiliateGroupProductive");

            builder.Entity<BriefcaseSocialNetwork>()
                .HasIndex(c => new { c.BriefcaseId, c.BriefcaseSocialNetworkId})
                .IsUnique()
                .HasDatabaseName("IX_BriefcaseSocialNetwork_BriefcaseSocialNetworkId");

            builder.Entity<Subscriber>()
                .HasIndex(c=>c.email)
                .IsUnique()
                .HasDatabaseName("IX_Subscriber_email");

            builder.Entity<SubscriberSector>()
                .HasIndex(c=>new { c.SubscriberId,c.PqrsStrategicLineSectorId })
                .IsUnique()
                .HasDatabaseName("IX_SubscriberSecto_SubscriberId_PqrsStrategicLineSectorId");

            //this.SeedRoles(builder);
            //this.SeedUsers(builder);
            //this.SeedUserRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            //var codigoAdmin = "fab4fac1-c546-41de-aebc-a14da6895711";
            //Guid codigoAdminTypist = Guid.NewGuid();
            //Guid codigoCustomer = Guid.NewGuid();

            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole() { Id = codigoAdmin, Name = "Administrador", ConcurrencyStamp = "1", NormalizedName = "Administrador" },
            //    new IdentityRole() { Id = codigoAdminTypist.ToString(), Name = "Publicador", ConcurrencyStamp = "2", NormalizedName = "Publidaro" },
            //    new IdentityRole() { Id = codigoCustomer.ToString(), Name = "Usuario", ConcurrencyStamp = "3", NormalizedName = "Usuario" }
            //);

            builder.Entity<Gender>().HasData
                (
                    new Gender() { GenderId = 1, GenderName = "Hombre" },
                    new Gender() { GenderId = 2, GenderName = "Mujer" },
                    new Gender() { GenderId = 3, GenderName = "Otro" }
                );

            builder.Entity<DocumentType>().HasData
                  (
                        new DocumentType() { DocumentTypeId = 1, DocumentTypeName = "Cédula de ciudadanía" },
                        new DocumentType() { DocumentTypeId = 2, DocumentTypeName = "Cédula de extranjería" }
                  );

            builder.Entity<PqrsStrategicLine>().HasData
                (
                    new PqrsStrategicLine() { PqrsStrategicLineId = 1, PqrsStrategicLineName = "Desarrollo social incluyente" },
                    new PqrsStrategicLine() { PqrsStrategicLineId = 2, PqrsStrategicLineName = "Crecimiento económico" },
                    new PqrsStrategicLine() { PqrsStrategicLineId = 3, PqrsStrategicLineName = "Arauca verde, ordenada y sostenible" },
                    new PqrsStrategicLine() { PqrsStrategicLineId = 4, PqrsStrategicLineName = "Infraestructura social y productiva" },
                    new PqrsStrategicLine() { PqrsStrategicLineId = 5, PqrsStrategicLineName = "Buen gobierno" },
                    new PqrsStrategicLine() { PqrsStrategicLineId = 6, PqrsStrategicLineName = "Seguridad convivencia y justicia" },
                    new PqrsStrategicLine() { PqrsStrategicLineId = 7, PqrsStrategicLineName = "Gestión del conocimiento" }
                );

            builder.Entity<State>().HasData
                (
                    new State() { StateId = 1, StateName = "Activo", StateB = true, StateType = "G" },
                    new State() { StateId = 2, StateName = "Inactivo", StateB = true, StateType = "G" },
                    new State() { StateId = 3, StateName = "Suspendido", StateB = true, StateType = "G" },
                    new State() { StateId = 4, StateName = "Eliminado", StateB = true, StateType = "G" },
                    new State() { StateId = 5, StateName = "Abierto", StateB = true, StateType = "P" },
                    new State() { StateId = 6, StateName = "En Trámite", StateB = true, StateType = "P" },
                    new State() { StateId = 7, StateName = "Cerrado", StateB = true, StateType = "P" }
                );

            builder.Entity<PqrsCategory>().HasData
                (
                    new PqrsCategory() { PqrsCategoryId = 1, PqrsCategoryName = "Peticiones", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryId = 2, PqrsCategoryName = "Quejas", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryId = 3, PqrsCategoryName = "Reclamos", StateId = 1 },
                    new PqrsCategory() { PqrsCategoryId = 4, PqrsCategoryName = "solicitudes", StateId = 1 }
                );

        }
        private void SeedUsers(ModelBuilder builder)
        {
            var user = new ApplicationUser()
            {
                UserName = "jomabero300@gmail.com",
                Email = "jomabero300@gmail.com",
                PhoneNumber = "1234567890",
                Document = "123456789",
                DocumentTypeId = 1,
                FirstName = "José Manuel",
                LastName = "Bello Romero",
                BirdDarte = DateTime.Parse("25/10/1972"),
                GenderId = 1,
                NormalizedUserName = "JOMABERO300@GMAIL.COM",
                NormalizedEmail = "JOMABERO300@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEEOLECkhbnucg2otJrS9mplc+yiiYBqr5cuAikFcjSRMG6W7burf/5xK770ySSigTg==",
                SecurityStamp = "5QOO4T3WALC3T34LQGO7NWPFH7N5TEMN",
                ConcurrencyStamp = "fad2ca03-488f-4542-8b65-d8cd1c14b4b7",
                LockoutEnabled = true,
                EmailConfirmed = true
            };

            builder.Entity<ApplicationUser>().HasData(user);

            var RolAdmin = new IdentityRole()
            {
                Name = "Administrador",
                NormalizedName = "Administrador",
                ConcurrencyStamp = "1"
            };

            var RolPublicador = new IdentityRole()
            {
                Name = "Publicador",
                NormalizedName = "Publicador",
                ConcurrencyStamp = "2"
            };

            var RolUsuario = new IdentityRole()
            {
                Name = "Usuario",
                NormalizedName = "Usuario",
                ConcurrencyStamp = "3"
            };

            builder.Entity<IdentityRole>().HasData(RolAdmin, RolPublicador, RolUsuario);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() { RoleId = RolAdmin.Id, UserId = user.Id });

        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

        public DbSet<Briefcase> Briefcases { get; set; }
        public DbSet<BriefcaseSocialNetwork> BriefcaseSocialNetworks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<CommuneTownship> CommuneTownships { get; set; }
        public DbSet<NeighborhoodSidewalk> NeighborhoodSidewalks { get; set; }

        public DbSet<GroupProductive> GroupProductive { get; set; }
        public DbSet<Pqrs> Pqrs { get; set; }
        public DbSet<PqrsAttachments> PqrsAttachments { get; set; }
        public DbSet<PqrsCategory> PqrsCategories { get; set; }
        public DbSet<PqrsStrategicLine> PqrsStrategicLines { get; set; }
        public DbSet<PqrsStrategicLineSector> PqrsStrategicLineSectors { get; set; }
        public DbSet<PqrsTraceability> PqrsTraceabilities { get; set; }
        public DbSet<PqrsUserStrategicLine> PqrsUserStrategicLines { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<SocialNetwork> SocialNetwork { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<AffiliateGroupCommunity> AffiliateGroupCommunities { get; set; }
        public DbSet<AffiliateGroupProductive> AffiliateGroupProductives { get; set; }
        public DbSet<AffiliateProfession> AffiliateProfessions { get; set; }
        public DbSet<AffiliateProfessionGallery> AffiliateProfessionGalleries { get; set; }
        public DbSet<AffiliateSocialNetwork> AffiliateSocialNetworks { get; set; }
        public DbSet<GroupCommunity> GroupCommunity { get; set; }
        public DbSet<PqrsProject> PqrsProjects { get; set; }
        public DbSet<PqrsProjectActivitie> PqrsProjectActivities { get; set; }
        public DbSet<PqrsProjectProponent> PqrsProponents { get; set; }
        public DbSet<PqrsProjectTraceability> PqrsProjectTraceabilities { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentDetail> ContentDetails { get; set; }
        public DbSet<ContentOds> ContentOds { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<SubscriberSector> SubscriberSectors { get; set; }
        public DbSet<SubscriberSend> SubscriberSends { get; set; }

    }
}
