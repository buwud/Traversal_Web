using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Admin.Models;

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
            var valueEntity = _guideService.GetList()[rand.Next(0,_guideService.GetList().Count)];

            var valueModel = new GuideEditViewModel
            {
                ImageURL = "/MemberImages/"+ valueEntity.Image,
                Name = valueEntity.Name,
                TwitterURL = valueEntity.TwitterURL,
                InstagramURL = valueEntity.InstagramURL
            };


            return View(valueModel);
        }
    }
}
