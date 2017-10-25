using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace testing.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<TotalFood> TotalFood { get; set; }
        public List<StoreUser> StoreUsers { get; set; }
        public List<FoodBankUser> FoodBankUsers { get; set; }
        public string Location { get; set; }
        public bool IsStore { get; set; }


        public ApplicationUser()
        {
            TotalFood = new List<TotalFood>();
            StoreUsers = new List<StoreUser>();
            FoodBankUsers = new List<FoodBankUser>();

        }
    }
}