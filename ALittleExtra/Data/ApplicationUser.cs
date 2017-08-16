using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ALittleExtra.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<TotalFood> TotalFood { get; set; }

        public ApplicationUser()
        {
            TotalFood = new List<TotalFood>();
        }
    }
}
