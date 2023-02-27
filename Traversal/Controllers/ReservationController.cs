using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        public IActionResult CurrReservation()
        {

            return View();
        }

        public IActionResult OldReservation()
        {

            return View();
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation r)
        {
            return View();
        }
    }
}