using System;
namespace ALittleExtra.Data
{
    public class Meat
    {
		public int Id { get; set; }
		public ApplicationUser Owner { get; set; }
        public string Type { get; set; }
		public string UserName { get; set; }
		public DateTime TimeStamp { get; set; }
    }
}
