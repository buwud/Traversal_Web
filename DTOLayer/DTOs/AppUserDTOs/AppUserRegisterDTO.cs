using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public List<SelectListItem>? GenderOptions { get; set; }
        public byte Age { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
