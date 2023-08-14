using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Traversal.Areas.Admin.Models.AppRole;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        [Route("UserList")]
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleViewModel> assignRoleViewModels= new List<AssignRoleViewModel>();
            foreach (var role in roles)
            {
                AssignRoleViewModel m = new AssignRoleViewModel();
                m.RoleID = role.Id;
                m.RoleName = role.Name;
                m.RoleExist = userRoles.Contains(role.Name);
                assignRoleViewModels.Add(m);
            }
            return View(assignRoleViewModels); 
        }
        [HttpPost]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> m) //birden fazla rolü olabilir
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach(var item in m)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }

    }
}
