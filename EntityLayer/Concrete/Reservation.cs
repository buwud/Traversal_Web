using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? PersonNum { get; set; }
        public string? Destination { get; set; }
        public string? Description { get; set; }
        public DateTime ReservationTime { get; set; }
        public string? Status { get; set; }
    }
}
