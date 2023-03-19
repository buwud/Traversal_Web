using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    [AllowAnonymous]
    public class _MemberGuidePartial:ViewComponent
    {
        GuideManager _guideManager = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = _guideManager.GetList();

            return View(values);
        }
    }
}
