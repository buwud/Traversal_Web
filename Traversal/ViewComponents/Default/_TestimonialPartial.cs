using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _TestimonialPartial:ViewComponent
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = _testimonialManager.GetList();
            return View(values);
        }
    }
}
