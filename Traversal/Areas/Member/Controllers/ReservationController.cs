using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());
        //REFACTORİNG EYLENECEK

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        /*public async Task<IActionResult> CurrReservation()
        {
            //???
            return View();
        }*/
        //var valueList = _reservationManager.GetListAll(values.Id);
        public async Task<IActionResult> MyReservations()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = _reservationManager.GetListAll(values.Id).OrderByDescending(x=>x.ReservationTime).ToList();
            ViewBag.table = valueList;

            var valueList1 = _reservationManager.GetListPreviousReservations(values.Id).OrderByDescending(x => x.ReservationTime).ToList();
            ViewBag.table1 = valueList1;

            return View();
        }
        public async Task<IActionResult> OldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = _reservationManager.GetListPreviousReservations(values.Id);
            return View(valueList);
        }
        public async Task<IActionResult> PendingReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = _reservationManager.GetListPending(values.Id);
            return View(valueList);
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
            if (result.IsValid)
            {
                r.AppUserId = 8;
                r.DestinationID = r.DestinationID;
                r.Status = "Waiting for approval";//başlangıçta onay bekliyo olcak sonra bunu onaylicaklar
                _reservationManager.TInsert(r);
                TempData["SuccessMessage"] = "Reservation created successfully! Stay tuned for updates for the approval process, check status on the current reservation page.";
                return RedirectToAction("CurrReservation");
            }
            else
            {
                foreach (var items in result.Errors)
                {
                    ModelState.AddModelError("", items.ErrorMessage);
                }
                TempData["ErrorMessage"] = "There was an error occurred in the process!";
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
            return View(r);
        }

    }
}