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


        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;

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
                    return Ok(new { IsAuthenticated = false });
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
    }
}
