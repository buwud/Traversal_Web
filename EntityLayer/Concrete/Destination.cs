using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Destination
	{
		[Key]
		public int DestinationID { get; set; }
		public string? City { get; set; }
		public string? StayTime { get; set; }
		public double? Price { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageS { get; set; }
        [NotMapped]
        public IFormFile? Image1 { get; set; }
        public string? Image1S { get; set; }
		[NotMapped]
		public IFormFile? CoverImage { get; set; }
		public string? CoverImageS { get; set; }
		public string? Description { get; set; }
		public string? Details { get; set; }
		public string? Details1 { get; set; }
		public int Capacity { get; set; }
		public bool Status { get; set; }
		public DateTime? Date { get; set; }
        public List<Reservation>? Reservations { get; set; }
		public int? GuideID { get; set; }
		public Guide? Guide { get; set; }
    }
}