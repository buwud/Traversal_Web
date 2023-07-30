using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public byte Age { get; set; }
        public string? Gender { get; set; }
        public string? ImageURL { get; set; }
        public List<Reservation> reservations { get; set; }
        public List<AppUser> appUsers { get; set; }
    }
}