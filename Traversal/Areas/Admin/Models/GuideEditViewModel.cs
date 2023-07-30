using System.ComponentModel.DataAnnotations;

namespace Traversal.Areas.Admin.Models
{
    public class GuideEditViewModel
    {
        [Key]
        public int GuideID { get; set; }

        [Required]
        [StringLength(500)]
        public string? Name { get; set; }

        public string ImageURL { get; set; }
        public IFormFile? Image { get; set; }

        [Required]
        [StringLength(60,MinimumLength =3)]
        public string? Description { get; set; }

        public string? TwitterURL { get; set; }
        public string? InstagramURL { get; set; }
        public bool Status { get; set; }
    }
}
