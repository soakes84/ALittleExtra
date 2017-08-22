using System;
namespace ALittleExtra.Data
{
    public class Vegetables
    {
		public int Id { get; set; }
		public ApplicationUser Owner { get; set; }
        public string Name { get; set; }
		public string UserName { get; set; }
		public DateTime TimeStamp { get; set; }
    }
}
