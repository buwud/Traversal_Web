using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());
        //REFACTORİNG EYLENECEK
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
            List<SelectListItem> values = (from x in _destinationManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,//destination tarafında city ismi kullanılacak
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation r)
        {
            r.AppUserId = 3;
            _reservationManager.TInsert(r);
            return RedirectToAction("CurrReservation");
        }
    }
}
