using System;

namespace testing.Data
{
    public class Fruit
    {
		public int Id { get; set; }
		public StoreUser Owner { get; set; }
        public string Name { get; set; }
		public string UserName { get; set; }
		public DateTime TimeStamp { get; set; }
    }
}