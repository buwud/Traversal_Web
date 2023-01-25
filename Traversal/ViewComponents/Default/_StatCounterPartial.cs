using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _StatCounterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1=c.Destinations.Count().ToString();
            ViewBag.v2 = c.Guides.Count().ToString();
            ViewBag.v3 = "345";
            //Müşteri tablosu eklenebilir sql e
            return View();
        }
    }
}
