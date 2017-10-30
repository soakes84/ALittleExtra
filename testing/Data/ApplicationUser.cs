using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace testing.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<TotalFood> TotalFood { get; set; }
        public List<DonatedFood> DonatedFood { get; set; }
        public string Location { get; set; }
        public bool IsStore { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }


        public ApplicationUser()
        {
            TotalFood = new List<TotalFood>();
            DonatedFood = new List<DonatedFood>();
        }
    }
}