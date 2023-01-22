using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	internal class About
	{
		public int AboutID { get; set; }
		public string? AboutDetails { get; set; }
		public string? Image { get; set; }
		public bool? Status { get; set; }
	}
}