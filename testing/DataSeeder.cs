using System;
using testing.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace testing
{
	public static class DataSeeder
	{
		public static async void SeedData(this IApplicationBuilder app)
		{
			var context = app.ApplicationServices.GetRequiredService<ALittleExtraContext>();
			var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
			var storeManager = app.ApplicationServices.GetRequiredService<UserManager<StoreUser>>();

			var appUser = await userManager.FindByEmailAsync("food@food.com");
			if (appUser == null)
			{
				appUser = new ApplicationUser();
				appUser.Email = "food@food.com";
				appUser.UserName = "Foodie123";
				await userManager.CreateAsync(appUser, "Testtest1");

				var user = new StoreUser();
				user.Email = "store@store.com";
				user.UserName = "Ukrops";
				await storeManager.CreateAsync(user, "Testtest1");

				var food = new TotalFood() { Type = "Meat" };
				food.UserName = user.UserName;
				user.TotalFood.Add(food);
				var meat = new Meat();
				meat.Owner = user;
				meat.UserName = user.UserName;
				meat.Name = "T-Bone Steak";
				context.Meat.Add(meat);

				var food1 = new TotalFood() { Type = "Meat" };
				food1.UserName = user.UserName;
				user.TotalFood.Add(food1);
				var meat1 = new Meat();
				meat1.Owner = user;
				meat1.UserName = user.UserName;
				meat1.Name = "Pork";
				context.Meat.Add(meat1);

				var food2 = new TotalFood() { Type = "Meat" };
				food2.UserName = user.UserName;
				user.TotalFood.Add(food2);
				var meat2 = new Meat();
				meat2.Owner = user;
				meat2.UserName = user.UserName;
				meat2.Name = "Chicken Breasts";
				context.Meat.Add(meat2);

				var food3 = new TotalFood() { Type = "Fruit" };
				food3.UserName = user.UserName;
				user.TotalFood.Add(food3);
				var fruit = new Fruit();
				fruit.Owner = user;
				fruit.UserName = user.UserName;
				fruit.Name = "Strawberries";
				context.Fruit.Add(fruit);

				var food4 = new TotalFood() { Type = "Fruit" };
				food4.UserName = user.UserName;
				user.TotalFood.Add(food4);
				var fruit1 = new Fruit();
				fruit1.Owner = user;
				fruit1.UserName = user.UserName;
				fruit1.Name = "Strawberries";
				context.Fruit.Add(fruit1);

				var food5 = new TotalFood() { Type = "CanFood" };
				food5.UserName = user.UserName;
				user.TotalFood.Add(food5);
				var canFood = new CanFood();
				canFood.Owner = user;
				canFood.UserName = user.UserName;
				canFood.Name = "Chicken Noodle Soup";
				context.CanFood.Add(canFood);

				var food6 = new TotalFood() { Type = "Dairy" };
				food6.UserName = user.UserName;
				user.TotalFood.Add(food6);
				var dairy = new Dairy();
				dairy.Owner = user;
				dairy.UserName = user.UserName;
				dairy.Name = "String Cheese";
				context.Dairy.Add(dairy);

				var food7 = new TotalFood() { Type = "Dairy" };
				food7.UserName = user.UserName;
				user.TotalFood.Add(food7);
				var dairy1 = new Dairy();
				dairy1.Owner = user;
				dairy1.UserName = user.UserName;
				dairy1.Name = "Swiss Cheese";
				context.Dairy.Add(dairy1);

			}
		}
	}
}

