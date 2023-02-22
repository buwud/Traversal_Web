using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage= "Enter your username")]
        [StringLength(42, MinimumLength = 3, ErrorMessage = "Minimum 3 and maximum 42 characters allowed")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Enter your password")]
        public string? Password { get; set; }
    }
}