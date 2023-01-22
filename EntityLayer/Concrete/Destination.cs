using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	internal class Destination
	{
		public int DestinationID { get; set; }
		public string? City { get; set; }
		public string? StayTime { get; set; }
		public double? Price { get; set; }
		public string? Image { get; set; }
		public string? Description { get; set; }
		public string? Capacity { get; set; }
		public bool Status { get; set; }


	}
}
