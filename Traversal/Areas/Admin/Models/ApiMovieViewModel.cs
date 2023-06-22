using DocumentFormat.OpenXml.Office2013.Excel;

namespace Traversal.Areas.Admin.Models
{
	public class ApiMovieViewModel
	{
        public int rank { get; set; }
		public string? title { get; set; }
		public string? description { get; set; }
        public string? director { get; set; }
        public string? genre { get; set; }
        public int? year { get;set; } 
        public string? rating { get; set; }
        public string? trailer { get; set; }
    
    }
}
