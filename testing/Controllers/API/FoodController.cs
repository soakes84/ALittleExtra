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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace testing.Controllers.API
{
    [Produces("application/json")]
    public class FoodController : Controller
    {
        private readonly ALittleExtraContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }

        public FoodController(UserManager<ApplicationUser> userManager, ALittleExtraContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // all food that has ever been donated from all store users
        [HttpGet]
        [Route("~/api/totalfood/all")]
        public IEnumerable<TotalFood> GetTotalFood()
        {
            return _context.TotalFood.Where(q => q.PickedUp == true).ToList();
        }

        // all food avail from all stores
        [HttpGet]
        [Route("~/api/totalfood/available")]
        public IEnumerable<TotalFood> GetTotalAvailableFood()
        {
            return _context.TotalFood.Where(q => q.Available == true).ToList();
        }

        // all food this logged in store user has donated
        [HttpGet]
        [Route("~/api/totalfood/donated")]
        public IEnumerable<TotalFood> GetStoreUserTotalFood()
        {
            var userName = _userManager.GetUserName(User);
            return _context.TotalFood.Where(q => q.UserName == userName && q.PickedUp == true).ToList();
        }

        // all food a particular store has donated
        [HttpGet]
        [Route("~/api/totalfood/donated/{id}")]
        public async Task<IActionResult> GetSingleStoreUserTotalFood(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = _userManager.GetUserId(User);
            TotalFood totalFood = await _context.TotalFood.Where(q => q.PickedUp == true)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (totalFood == null)
            {
                return NotFound(id);
            }

            return Ok(totalFood);
        }

        // all available boxfood from all users
        [HttpGet]
        [Route("~/api/totalfood/available/boxfood")]
        public IEnumerable<BoxFood> GetBoxFoodTotals()
        {
            return _context.BoxFood.Where(q => q.Available == true).ToList();
        }

        // all avail canfood from all users
        [HttpGet]
        [Route("~/api/totalfood/available/canfood")]
        public IEnumerable<CanFood> GetCanFoodTotals()
        {
            return _context.CanFood.Where(q => q.Available == true).ToList();
        }

        // all avail fruit from all users
        [HttpGet]
        [Route("~/api/totalfood/available/fruit")]
        public IEnumerable<Fruit> GetFruitTotals()
        {
            return _context.Fruit.Where(q => q.Available == true).ToList();
        }

        // all avail Meat from all users
        [HttpGet]
        [Route("~/api/totalfood/available/meat")]
        public IEnumerable<Meat> GetMeatTotals()
        {
            return _context.Meat.Where(q => q.Available == true).ToList();
        }

        // all avail vegetables from all users
        [HttpGet]
        [Route("~/api/totalfood/available/vegetables")]
        public IEnumerable<Vegetables> GetVegetabesTotals()
        {
            return _context.Vegetables.Where(q => q.Available == true).ToList();
        }

        // all boxfood from logged in user
        [HttpGet]
        [Route("~/api/totalfood/boxfood")]
        public IEnumerable<BoxFood> GetStoreUserBoxFoodTotal()
        {
            var userName = _userManager.GetUserName(User);
            return _context.BoxFood.Where(q => q.UserName == userName && q.Available == true).ToList();
        }

        // all canfood from logged in user
        [HttpGet]
        [Route("~/api/totalfood/canfood")]
        public IEnumerable<CanFood> GetStoreUserCanFoodTotal()
        {
            var userName = _userManager.GetUserName(User);
            return _context.CanFood.Where(q => q.UserName == userName && q.Available == true).ToList();
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
        //[Authorize]
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
                    item.PickedUp = false;
                    item.Available = true;
                    item.Selected = false;
                    _context.TotalFood.Add(item);

                    if (item.Type == "Box Food")
                    {
                        var boxFood = new BoxFood();
                        boxFood.Owner = user;
                        boxFood.UserName = user.UserName;
                        boxFood.TimeStamp = DateTime.UtcNow;
                        boxFood.PickedUp = false;
                        boxFood.Available = true;
                        boxFood.Selected = false;
                        _context.BoxFood.Add(boxFood);
                    }
                    else if (item.Type == "Can Food")
                    {
                        var canFood = new CanFood();
                        canFood.Owner = user;
                        canFood.UserName = user.UserName;
                        canFood.TimeStamp = DateTime.UtcNow;
                        canFood.PickedUp = false;
                        canFood.Available = true;
                        canFood.Selected = false;
                        _context.CanFood.Add(canFood);
                    }
                    else if (item.Type == "Fruit")
                    {
                        var fruit = new Fruit();
                        fruit.Owner = user;
                        fruit.UserName = user.UserName;
                        fruit.TimeStamp = DateTime.UtcNow;
                        fruit.PickedUp = false;
                        fruit.Available = true;
                        fruit.Selected = false;
                        _context.Fruit.Add(fruit);
                    }
                    else if (item.Type == "Meat")
                    {
                        var meat = new Meat();
                        meat.Owner = user;
                        meat.UserName = user.UserName;
                        meat.TimeStamp = DateTime.UtcNow;
                        meat.PickedUp = false;
                        meat.Available = true;
                        meat.Selected = false;
                        _context.Meat.Add(meat);
                    }
                    else if (item.Type == "Vegetables")
                    {
                        var veggies = new Vegetables();
                        veggies.Owner = user;
                        veggies.UserName = user.UserName;
                        veggies.TimeStamp = DateTime.UtcNow;
                        veggies.PickedUp = false;
                        veggies.Available = true;
                        veggies.Selected = false;
                        _context.Vegetables.Add(veggies);
                    }
                    else if (item.Type == "Dairy")
                    {
                        var dairy = new Dairy();
                        dairy.Owner = user;
                        dairy.UserName = user.UserName;
                        dairy.TimeStamp = DateTime.UtcNow;
                        dairy.PickedUp = false;
                        dairy.Available = true;
                        dairy.Selected = false;
                        _context.Dairy.Add(dairy);
                    }
                    else if (item.Type == "Drinks")
                    {
                        var drink = new Drinks();
                        drink.Owner = user;
                        drink.UserName = user.UserName;
                        drink.TimeStamp = DateTime.UtcNow;
                        drink.PickedUp = false;
                        drink.Available = true;
                        drink.Selected = false;
                        _context.Drinks.Add(drink);
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
