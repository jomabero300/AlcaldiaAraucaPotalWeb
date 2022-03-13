using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Acti;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Admi;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Proc;
using AlcaldiaAraucaPortalWeb.Helper.Entities.Susc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcaldiaAraucaPortalWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();


            //options => options.SignIn.RequireConfirmedAccount= true
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABDCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            })
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddScoped<IDocumentTypeHelper, DocumentTypeHelper>();
            services.AddScoped<IGenderHelper, GenderHelper>();
            services.AddScoped<IPqrsCategoryHelper, PqrsCategoryHelper>();
            services.AddScoped<IPqrsStrategicLineHelper, PqrsStrategicLineHelper>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IStateHelper, StateHelper>();
            services.AddScoped<IPqrsUserStrategicLineHelper, PqrsUserStrategicLineHelper>();
            services.AddScoped<IAffiliateHelper, AffiliateHelper>();
            services.AddScoped<IGroupProductiveHelper, GroupProductiveHelper>();
            services.AddScoped<ISocialNetworkHelper, SocialNetworkHelper>();
            services.AddScoped<IProfessionHelper, ProfessionHelper>();
            services.AddScoped<IGroupCommunityHelper, GroupCommunityHelper>();
            services.AddScoped<IAffiliateGroupProductiveHelper, AffiliateGroupProductiveHelper>();
            services.AddScoped<IBriefcaseHelper, BriefcaseHelper>();
            services.AddScoped<IBriefcaseSocialNetworkHelper, BriefcaseSocialNetworkHelper>();
            services.AddScoped<IZoneHelper, ZoneHelper>();
            services.AddScoped<ICommuneTownshipHelper, CommuneTownshipHelper>();
            services.AddScoped<INeighborhoodSidewalkHelper, NeighborhoodSidewalkHelper>();
            services.AddScoped<IPqrsStrategicLineSectorHelper, PqrsStrategicLineSectorHelper>();
            services.AddScoped<IContentHelper, ContentHelper>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IMailHelper, MailHelper>();
            services.AddScoped<IContentOdsHelper, ContentOdsHelper>();
            services.AddScoped<IPqrsAttachmentsHelper, PqrsAttachmentsHelper>();
            services.AddScoped<IPqrsTraceabilityHelper, PqrsTraceabilityHelper>();
            services.AddScoped<IPqrsProjectActivitieHelper, PqrsProjectActivitieHelper>();
            services.AddScoped<IAffiliateProfessionHelper, AffiliateProfessionHelper>();
            services.AddScoped<IAffiliateSocialNetworkHelper, AffiliateSocialNetworkHelper>();
            services.AddScoped<IRoleHelper, RoleHelper>();
            services.AddScoped<ISubscriberHelper, SubscriberHelper>();
            services.AddScoped<ISubscriberSectorHelper, SubscriberSectorHelper>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            //SeedDb.Seed(app);
        }
    }
}
