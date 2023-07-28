using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _FeaturePartial:ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.GetList().OrderBy(x => x.Capacity).ToList();

            ViewBag.v1DayNite = values[0].StayTime;
            ViewBag.v1Price = values[0].Price;
            ViewBag.v1Img = values[0].ImageS;

            ViewBag.v2DayNite = values[1].StayTime;
            ViewBag.v2Price = values[1].Price;
            ViewBag.v2Img = values[1].ImageS;
                
            ViewBag.v3DayNite = values[2].StayTime;
            ViewBag.v3Price = values[2].Price;
            ViewBag.v3Img = values[2].ImageS;

            ViewBag.v4DayNite = values[3].StayTime;
            ViewBag.v4Price = values[3].Price;
            ViewBag.v4Img = values[3].ImageS;

            ViewBag.v5DayNite = values[4].StayTime;
            ViewBag.v5Price = values[4].Price;
            ViewBag.v5Img = values[4].ImageS;

            return View();
        }//en az capacitysi olan 5 tane listelenecek
    }
}