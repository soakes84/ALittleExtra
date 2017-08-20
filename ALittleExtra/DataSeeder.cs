using System;
using ALittleExtra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ALittleExtra
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ALittleExtraContext>();
            var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            var storeManager = app.ApplicationServices.GetRequiredService<UserManager<StoreUser>>();

            var user = await userManager.FindByEmailAsync("food@food.com");
            if (user == null)
            {
                
            }
        }
    }
}
