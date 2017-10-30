using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testing.Data;
using testing.Models;
using Microsoft.AspNetCore.Identity;


namespace testing.Controllers.API
{
    [Produces("application/json")]
    public class AccountsController : Controller
    {
        public SignInManager<ApplicationUser> SignInManager { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }
        private readonly ALittleExtraContext _context;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ALittleExtraContext context )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = context;

        }

		[HttpPost]
        [Route("~/api/accounts/login")]
        public async Task<IActionResult> StoreLogin ([FromBody]LoginRequest model)
		{
            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, true);
                if(result.Succeeded)
                {
                    return Ok(new { IsAuthenticated = true, Name = user.UserName, Location = user.Location, Email = user.Email, IsStore = user.IsStore  });
                }
                else{
                    return BadRequest(new { IsAuthenticated = false });
                }
            }
            else
            {
                return BadRequest();
            }
		}
   
        [HttpPost]
        [Route("~/api/accounts/register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest model)
        {
            
            var user = new ApplicationUser();
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Location = model.Location;
            user.Latitude = model.Latitude;
            user.Longitude = model.Longitude;
            user.IsStore = model.IsStore;

            if(model.IsStore == true)
            {

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }  
        }

		[HttpGet]
        [Route("~/api/accounts/logout")]
		public async Task<IActionResult> Logout()
		{
            await SignInManager.SignOutAsync();

            return Ok();
		}

        [HttpGet]
        [Route("~/api/accounts/stores")]
        public IEnumerable<String> GetFoodStores()
        {
            var foodStores = new List<String>(); 
           var stores = _context.Users.Where(q => q.IsStore == true).ToList();
            foreach(var store in stores)
            {
                foodStores.Add(store.UserName);
                foodStores.Add(store.Location);
                foodStores.Add(store.Id);
                foodStores.Add(store.Email);
            }

            return foodStores;
        }
    }
}
