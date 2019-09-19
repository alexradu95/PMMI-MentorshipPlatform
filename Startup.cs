using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Siemens.MP.Areas.Identity;
using Siemens.MP.Data;
using Siemens.MP.Entities;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using System.Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using Siemens.MP.Enums;
using Siemens.MP.Data.Repositories;
using Microsoft.AspNetCore.Http;

namespace Siemens.MP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<GenericRepository<Project>>();
            services.AddScoped<GenericRepository<Siemens.MP.Entities.Task>>();
            services.AddScoped<GenericRepository<Siemens.MP.Entities.Article>>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
             services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

        }
        private async System.Threading.Tasks.Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { RoleType.ADMIN.ToString(), RoleType.MENTOR.ToString(), RoleType.STUDENT.ToString()};
            IdentityResult roleResult;
            
            
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var poweruser = new IdentityUser
            {

                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = "1q2w3e4rT!";
            var _user = await UserManager.FindByEmailAsync("admin@gmail.com");
        
            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser,userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser,RoleType.ADMIN.ToString());

                }
            }
            
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , IServiceProvider serviceProvider)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            CreateRoles(serviceProvider).Wait();
            
        }
        
    }
    
}
