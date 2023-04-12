using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(CityClasses);
            return Json(jsonCity);
        }

        public static List<CityClass> CityClasses = new List<CityClass>()
        {
            new CityClass
            {
                CityID=1,
                CityName="Kayseri",
                CityCountry="Türkiye"
            },
            new CityClass
            {
                CityID=2,
                CityName="Roma",
                CityCountry="Italy"
            },
            new CityClass
            {
                CityID=2,
                CityName="Londra",
                CityCountry="England"
            },
        };
    }
}
