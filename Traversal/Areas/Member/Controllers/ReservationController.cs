using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
            List<SelectListItem> values = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Select Destination --", Selected = true }
            };
            values.AddRange(from x in _destinationManager.GetList()
                            select new SelectListItem
                            {
                                Text = x.City,
                                Value = x.DestinationID.ToString()
                            });

            ViewBag.values = values;
            return View();
        }


        [HttpPost]
        public IActionResult NewReservation(Reservation r)
        {
            NewReservationValidator validationRules = new NewReservationValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(r);
            if (ModelState.IsValid)
            {
                if (result.IsValid)
                {
                    r.AppUserId = 3;
                    _reservationManager.TInsert(r);
                    return RedirectToAction("CurrReservation");
                }
            }
            else
            {
                foreach (var items in result.Errors)
                {
                    ModelState.AddModelError("", items.ErrorMessage);
                }
            }
            List<SelectListItem> values = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Select Destination --", Selected = true }
            };
            values.AddRange(from x in _destinationManager.GetList()
                            select new SelectListItem
                            {
                                Text = x.City,
                                Value = x.DestinationID.ToString()
                            });

            ViewBag.values = values;
            return View();
        }
    }
}