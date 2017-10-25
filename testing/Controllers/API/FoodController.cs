using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testing.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testing.Controllers.API
{
    [Produces("application/json")]
    public class FoodController : Controller
    {
        private readonly ALittleExtraContext _context;
        private UserManager<StoreUser> _userManager { get; set; }

        public FoodController(UserManager<StoreUser> userManager, ALittleExtraContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // all food that has ever been donated from all store users
		[HttpGet]
		[Route("~/api/totalfood/all")]
		public IEnumerable<TotalFood> GetTotalFood()
		{
			return _context.TotalFood.ToList();
		}

        // all food this logged in store user has donated
        [HttpGet]
        [Route("~/api/totalfood")]
        public IEnumerable<TotalFood> GetStoreUserTotalFood()
        {
            var userName = _userManager.GetUserName(User);
            return _context.TotalFood.Where(q => q.UserName == userName).ToList();
        }

		// all food a particular store has donated
		[HttpGet]
        [Route("~/api/totalfood/{id}")]
        public async Task<IActionResult> GetSingleStoreUserTotalFood(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userId = _userManager.GetUserId(User);
            TotalFood totalFood = await _context.TotalFood
				.SingleOrDefaultAsync(p => p.Id == id);

            if (totalFood == null)
			{
                return NotFound(id);
			}

            return Ok(totalFood);
		}

		// all boxfood from all users
		[HttpGet]
		[Route("~/api/totalfood/all/boxfood")]
		public IEnumerable<BoxFood> GetBoxFoodTotals()
		{
			return _context.BoxFood.ToList();
		}

		// all canfood from all users
		[HttpGet]
		[Route("~/api/totalfood/all/canfood")]
		public IEnumerable<CanFood> GetCanFoodTotals()
		{
			return _context.CanFood.ToList();
		}

		// all fruit from all users
		[HttpGet]
		[Route("~/api/totalfood/all/fruit")]
		public IEnumerable<Fruit> GetFruitTotals()
		{
			return _context.Fruit.ToList();
		}

		// all Meat from all users
		[HttpGet]
		[Route("~/api/totalfood/all/meat")]
		public IEnumerable<Meat> GetMeatTotals()
		{
			return _context.Meat.ToList();
		}

		// all vegetables from all users
		[HttpGet]
		[Route("~/api/totalfood/all/vegetables")]
        public IEnumerable<Vegetables> GetVegetabesTotals()
		{
            return _context.Vegetables.ToList();
		}

		// all boxfood from logged in user
		[HttpGet]
		[Route("~/api/totalfood/boxfood")]
		public IEnumerable<BoxFood> GetStoreUserBoxFoodTotal()
		{
            var userName = _userManager.GetUserName(User);
            return _context.BoxFood.Where(q => q.UserName == userName).ToList();
		}

		// all canfood from logged in user
		[HttpGet]
		[Route("~/api/totalfood/canfood")]
		public IEnumerable<CanFood> GetStoreUserCanFoodTotal()
		{
			var userName = _userManager.GetUserName(User);
			return _context.CanFood.Where(q => q.UserName == userName).ToList();
		}

		// all fruit from logged in user
		[HttpGet]
		[Route("~/api/totalfood/fruit")]
        public IEnumerable<Fruit> GetStoreUserFruitTotal()
		{
			var userName = _userManager.GetUserName(User);
            return _context.Fruit.Where(q => q.UserName == userName).ToList();
		}

		// all Meat from logged in user
		[HttpGet]
		[Route("~/api/totalfood/meat")]
		public IEnumerable<Meat> GetStoreUserMeatTotal()
		{
			var userName = _userManager.GetUserName(User);
			return _context.Meat.Where(q => q.UserName == userName).ToList();
		}

		// all vegetables from logged in user
		[HttpGet]
		[Route("~/api/totalfood/vegetables")]
        public IEnumerable<Vegetables> GetStoreUserVegetablesTotal()
		{
			var userName = _userManager.GetUserName(User);
            return _context.Vegetables.Where(q => q.UserName == userName).ToList();
		}

        // storeuser posting their food items
        [HttpPost]
        [Route("~/api/food/totalfood")]
        [Authorize]
        public async Task<IActionResult> PostFood([FromBody] List<TotalFood> food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);

            foreach (var item in food)
            {
                for (int i = 0; i <= item.Quantity; i++)
                {
                    user.TotalFood.Add(item);
                    item.UserName = user.UserName;
                    item.TimeStamp = DateTime.UtcNow;
                    _context.TotalFood.Add(item);

                    if (item.Type == "Box Food")
                    {
                        var boxFood = new BoxFood();
                        boxFood.Owner = user;
                        boxFood.UserName = user.UserName;
                        boxFood.TimeStamp = DateTime.UtcNow;
                        _context.BoxFood.Add(boxFood);
                    }
                    else if (item.Type == "Can Food")
                    {
						var canFood = new CanFood();
                        canFood.Owner = user;
                        canFood.UserName = user.UserName;
                        canFood.TimeStamp = DateTime.UtcNow;
						_context.CanFood.Add(canFood);
                    }
                    else if (item.Type == "Fruit")
                    {
						var fruit = new Fruit();
                        fruit.Owner = user;
                        fruit.UserName = user.UserName;
                        fruit.TimeStamp = DateTime.UtcNow;
						_context.Fruit.Add(fruit);
                    }
                    else if (item.Type == "Meat")
                    {
						var meat = new Meat();
						meat.Owner = user;
						meat.UserName = user.UserName;
						meat.TimeStamp = DateTime.UtcNow;
						_context.Meat.Add(meat);
                    }
                    else if (item.Type == "Vegetables")
                    {
                        var veggies = new Vegetables();
                        veggies.Owner = user;
                        veggies.UserName = user.UserName;
                        veggies.TimeStamp = DateTime.UtcNow;
                        _context.Vegetables.Add(veggies);
                    }
                    else if (item.Type == "Dairy")
					{
						var dairy = new Dairy();
                        dairy.Owner = user;
                        dairy.UserName = user.UserName;
                        dairy.TimeStamp = DateTime.UtcNow;
						_context.Dairy.Add(dairy);
					}
                    else if (item.Type == "Drinks")
					{
                        var drinks = new Drinks();
                        drinks.Owner = user;
                        drinks.UserName = user.UserName;
                        drinks.TimeStamp = DateTime.UtcNow;
                        _context.Drinks.Add(drinks);
					}
                }

                item.Quantity = 0;
            }

            await _context.SaveChangesAsync();

            return Ok(food);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
