using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Feature
	{
		[Key]
		public int FeatureID { get; set; }
		public string? post1Name  { get; set; }
		public string? post1Description  { get; set; }
		public string? post1Image  { get; set; }
		public bool? post1Status  { get; set; }
		//durumu true olan 4 satır olcak
	}
}