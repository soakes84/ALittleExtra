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
        public SignInManager<StoreUser> SignInManager { get; set; }
        public UserManager<StoreUser> UserManager { get; set; }
        public UserManager<ApplicationUser> ApplicationManager { get; set; }
        public SignInManager<ApplicationUser> SignInStore { get; set; }

        public AccountsController(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager,
                                  UserManager<ApplicationUser> applicationManager, SignInManager<ApplicationUser> signInBank)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            ApplicationManager = applicationManager;
            SignInStore = signInBank;

        }

		[HttpPost]
        [Route("~/api/accounts/store/login")]
        public async Task<IActionResult> StoreLogin ([FromBody]LoginRequest model)
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

        [HttpPost]
        [Route("~/api/accounts/bank/login")]
        public async Task<IActionResult> BankLogin ([FromBody]LoginRequest model)
        {
            var user = await ApplicationManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await SignInStore.PasswordSignInAsync(user, model.Password, false, true);
                if (result.Succeeded)
                {
                    return Ok(new { IsAuthenticated = true, Name = user.Email });
                }
                else
                {
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
            if(model.IsStore)
            {
                var user = new StoreUser();
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Location = model.Location;


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
                var user = new ApplicationUser();
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await ApplicationManager.CreateAsync(user, model.Password);

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
