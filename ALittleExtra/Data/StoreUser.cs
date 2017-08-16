using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ALittleExtra.Data
{
    public class StoreUser : IdentityUser
    { 
        public List<TotalFood> TotalFood { get; set; }

        public StoreUser()
        {
            TotalFood = new List<TotalFood>();
        }
    }
}
