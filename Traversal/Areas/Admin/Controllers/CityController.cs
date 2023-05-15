using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDes(Destination destination)
        {
            _destinationService.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
        public IActionResult DesList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList());
            return Json(jsonCity);
        }
        public IActionResult GetByID(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID); 
            return Json(JsonConvert.SerializeObject(values));
        }
        public IActionResult DeleteCity(int id)
        {
            var value = _destinationService.TGetByID(id);
            _destinationService.TDelete(value);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination d)
        {
            var value = _destinationService.TGetByID(d.DestinationID);

            d.Status = value.Status;
            d.City=value.City;
            d.Description = value.Description;
            d.Details = value.Details;
            d.Details1 = value.Details1;
            d.CoverImage = value.CoverImage;
            d.Image1 = value.Image1;
            d.Image1S = value.Image1S;

            _destinationService.TUpdate(d);
            var values = JsonConvert.SerializeObject(value);
            return Json(values);
        }
    }
}