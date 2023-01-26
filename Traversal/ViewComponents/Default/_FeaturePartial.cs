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
            List<Destination> maxs = new List<Destination>();
            var values = _destinationManager.GetList().OrderBy(x => x.Capacity).ToList();

            ViewBag.v1DayNite = values[0].Capacity;
            ViewBag.v1Price = values[0].Price;
            ViewBag.v1Img = values[0].Image;

            ViewBag.v2DayNite = values[1].Capacity;
            ViewBag.v2Price = values[1].Price;
            ViewBag.v2Img = values[1].Image;
                
            ViewBag.v3DayNite = values[2].Capacity;
            ViewBag.v3Price = values[2].Price;
            ViewBag.v3Img = values[2].Image;

            ViewBag.v4DayNite = values[3].Capacity;
            ViewBag.v4Price = values[3].Price;
            ViewBag.v4Img = values[3].Image;

            ViewBag.v5DayNite = values[4].Capacity;
            ViewBag.v5Price = values[4].Price;
            ViewBag.v5Img = values[4].Image;

            return View();
        }//en çok capacitysi olan 5 tane listelenecek
    }
}