using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using HairDemoSite.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using HairDemoSite.Areas.ClientAdmin.Data.Identity;
using HairDemoSite.Areas.Public.Data.SiteData;
using HairDemoSite.Areas.Public.Models;
using Microsoft.Extensions.Logging;
using HairDemoSite.Areas.ClientAdmin.Models;

namespace HairDemoSite
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
            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //    options.HttpsPort = 443;
            //});

            services.AddDbContext<siteDataDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RemoteConnection"))); // LocalConnection

            services.AddDbContext<LoginDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RemoteConnection"))); // LocalConnection

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LoginDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<StartPageData>();
            services.AddTransient<StartPageFlatData>();
            services.AddTransient<Carousel>();
            services.AddTransient<OurServices>();
            services.AddTransient<ImageDBCreator>();
            services.AddTransient<SiteImageModel>();
            services.AddTransient<Areas.Public.Models.PageFooter>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddLogging();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "PublicArea",
                    areaName: "Public",
                    pattern: "/{controller=Main}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "ClientAdminArea",
                    areaName: "ClientAdmin",
                    pattern: "ClientAdmin/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "API",
                    pattern: "api/[controller]/[action]/{id?}");

                endpoints.MapRazorPages();

            });
        }
    }
}
