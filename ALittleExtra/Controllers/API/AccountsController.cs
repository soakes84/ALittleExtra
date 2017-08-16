using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALittleExtra.Data;
using ALittleExtra.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALittleExtra.Controllers.API
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        public SignInManager<ApplicationUser> SignInManager { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

		// POST api/values
		[HttpPost]
        [Route("~/api/accounts/login")]
        public async Task<IActionResult> Login ([FromBody]LoginRequest model)
		{
            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, true);
                if(result.Succeeded)
                {
                    return Ok(new { IsAuthenticated = true, Name = user.Email });
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

   
        // POST api/values
        [HttpPost]
        [Route("~/api/accounts/register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest model)
        {
            var user = new ApplicationUser();
            user.Email = model.Email;
            user.UserName = model.UserName;

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

		// GET: api/values
		[HttpGet]
        [Route("~/api/accounts/logout")]
		public async Task<IActionResult> Logout()
		{
            await SignInManager.SignOutAsync();

            return Ok();
		}

    }
}
