using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Admin.Models.AppRole;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [Route("CreateRole")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [Route("CreateRole")]
        [HttpPost]
        public async Task <IActionResult> CreateRole(CreateRoleViewModel m)
        {
            AppRole role = new AppRole()
            {
                Name = m.Name,
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            return View(m);
        }

        //delete
        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value=_roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        //edit
        [Route("EditRole/{id}")]
        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            EditRoleViewModel editRoleViewModel = new EditRoleViewModel
            {
                RoleID = value.Id,
                Name = value.Name
            };
            return View(editRoleViewModel);
        }
        [Route("EditRole/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel m)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == m.RoleID);
            value.Name = m.Name;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }

    }
}
