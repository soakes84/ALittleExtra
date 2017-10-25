using System;

namespace testing.Data
{
    public class Vegetables
    {
		public int Id { get; set; }
		public StoreUser Owner { get; set; }
		public string UserName { get; set; }
		public DateTime TimeStamp { get; set; }
    }
}