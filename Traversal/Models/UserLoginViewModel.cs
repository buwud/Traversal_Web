using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage= "Enter your username")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Enter your password")]
        public string? Password { get; set; }
    }
}