using System;

namespace testing.Data
{
    public class Meat
    {
		public int Id { get; set; }
		public ApplicationUser Owner { get; set; }
        public string Name { get; set; }
		public string UserName { get; set; }
		public DateTime TimeStamp { get; set; }
        public bool PickedUp { get; set; }
        public bool Selected { get; set; }
        public bool Available { get; set; }
    }
}
