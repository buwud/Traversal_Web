using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _DestinationsGuide:ViewComponent
    {
        private readonly IGuideService _guideService;

        public _DestinationsGuide(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            Random rand=new Random();   
            var value = _guideService.TGetByID(rand.Next(0,_guideService.GetList().Count-1));
            return View(value);
        }
    }
}
