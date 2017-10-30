using System;
using System.Collections.Generic;

namespace testing.Data
{
    public class DonatedFood
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public string FoodBankName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
