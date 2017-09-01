using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace testing.Data
{
    public class TotalFood
    {
		public int Id { get; set; }
		public string Type { get; set; }
		public int Quantity { get; set; }
		public string UserName { get; set; }
		public virtual List<TotalFood> totalFood { get; set; }
		public DateTime TimeStamp { get; set; }
    }
}