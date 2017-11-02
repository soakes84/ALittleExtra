using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace testing
{
       public class Startup
	   {
	       public Startup(IHostingEnvironment env)
	       {
	           var builder = new ConfigurationBuilder()
	               .SetBasePath(env.ContentRootPath)
	               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
	               .AddEnvironmentVariables();
	           Configuration = builder.Build();
	       }

	       public IConfigurationRoot Configuration { get; }

	       // This method gets called by the runtime. Use this method to add services to the container.
	       public void ConfigureServices(IServiceCollection services)
	       {
	          // Add framework services.
	           var context = new ALittleExtraContext();
	           context.Database.Migrate();

	           services.AddDbContext<ALittleExtraContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
				{
					options.Password.RequireUppercase = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireDigit = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequiredLength = 2;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+. ";

				})
				.AddEntityFrameworkStores<ALittleExtraContext>()
				.AddDefaultTokenProviders();

	           services.AddMvc();
	       }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
             //app.SeedData();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //var context = app.ApplicationServices.GetRequiredService<ALittleExtraContext>();
            //var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();

            //var appUser = await userManager.FindByEmailAsync("food@food.com");
            //if (appUser == null)
            //{
                //appUser = new ApplicationUser
                //{
                //    Email = "food@food.com",
                //    UserName = "Foodie123",
                //    Location = "17A Princess St, Charleston, SC, 29401",
                //    IsStore = false
                //};
                //await userManager.CreateAsync(appUser, "Testtest1");

                //var user = new ApplicationUser
                //{
                //    Email = "store@store.com",
                //    UserName = "Bilo Folly",
                //    IsStore = true,
                //    Location = "890 Folly Rd, Charleston, SC, 29412"
                //};
                //await userManager.CreateAsync(user, "Testtest1");
               // context.SaveChanges();

                //var food = new TotalFood() { Type = "Meat" };
                //food.UserName = user.UserName;
                //user.TotalFood.Add(food);
                //var meat = new Meat();
                //meat.Owner = user;
                //meat.UserName = user.UserName;
                //meat.Name = "T-Bone Big Boy";
                //context.Meat.Add(meat);
            //}
        }

	   }
}
