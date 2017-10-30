using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using testing.Data;

namespace testing.Controllers.API
{
    [Produces("application/json")]
    public class StoresController : Controller
    {
        private readonly ALittleExtraContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }

        public StoresController(UserManager<ApplicationUser> userManager, ALittleExtraContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        [HttpGet]
        [Route("~/api/stores/all")]
        public IEnumerable<String> GetAllFoodStores()
        {
            var foodStores = new List<String>();
            var stores = _context.Users.Where(q => q.IsStore == true).ToList();
            foreach (var store in stores)
            {
                foodStores.Add(store.UserName);
                foodStores.Add(store.Location);
                foodStores.Add(store.Id);
                foodStores.Add(store.Email);
            }

            return foodStores;
        }
        
        [HttpGet]
        [Route("~/api/stores/")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        [Route("~/api/stores/{id}")]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
