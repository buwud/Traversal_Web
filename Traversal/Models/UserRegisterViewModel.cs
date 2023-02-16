using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Enter your name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter your surname")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter your username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Enter your phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Select your gender")]
        public string? Gender { get; set; }
        
        [Required(ErrorMessage = "Enter your age")]
        [Range(18,150,ErrorMessage ="Enter your age correctly")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}