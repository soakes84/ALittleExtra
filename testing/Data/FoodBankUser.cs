using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace testing.Data
{
    public class FoodBankUser : IdentityUser
    {
        public List<TotalFood> TotalFood { get; set; }
        public string Location { get; set; }
        public bool IsStore { get; set; }

        public FoodBankUser()
        {
            TotalFood = new List<TotalFood>();
        }
    }
}
