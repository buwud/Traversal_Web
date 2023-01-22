using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Contact
	{
		[Key]
		public int ContactID { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }
		public string? Number { get; set; }
		public string? Map { get; set; }
		public bool Status { get; set; }

	}
}