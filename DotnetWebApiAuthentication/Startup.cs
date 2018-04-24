using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DotnNetWebApiAuthentication.Data;
using DotnNetWebApiAuthentication.Models;
using DotnNetWebApiAuthentication.Services;
using DotnNetWebApiAuthentication.Intefaces;
using DotnNetWebApiAuthentication.Helpers;


namespace Dotnet_Core_Api_Authentication_with_Anguar_5
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
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IAccountService,AccountServices>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              RoleManager<IdentityRole> roleManager, 
                              UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             //create roles needed for application

            EnsureRolesAsync(roleManager).Wait();

            //Create an account and make it administrator
            AssignAdminRole(userManager).Wait();

            app.UseMvc();
        }

         public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExistsAdmin = await roleManager.RoleExistsAsync(Constants.Strings.UserRolls.AdministrationRole);
            var alreadyExistsSimpleUser = await roleManager.RoleExistsAsync(Constants.Strings.UserRolls.SimpleUser);

            if(alreadyExistsAdmin) return; 
            else await roleManager.CreateAsync(new IdentityRole(Constants.Strings.UserRolls.AdministrationRole));

            if(alreadyExistsSimpleUser) return;
            else await roleManager.CreateAsync(new IdentityRole(Constants.Strings.UserRolls.SimpleUser));
        }

        public static async Task AssignAdminRole(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users.Where(x => x.UserName == "IAmMonmoy").SingleOrDefaultAsync();
            if(testAdmin == null)
            {
                testAdmin = new ApplicationUser
                {
                    UserName = "IAmMonmoy",
                    Email = "iammonmoy@gmail.com"
                };

                await userManager.CreateAsync(testAdmin,"512345Rrm_");
            }
            else
            {
               var isAdmin = await userManager.IsInRoleAsync(testAdmin,Constants.Strings.UserRolls.AdministrationRole);
               if(!isAdmin) await userManager.AddToRoleAsync(testAdmin,Constants.Strings.UserRolls.AdministrationRole);
            }
        }
    }
}
