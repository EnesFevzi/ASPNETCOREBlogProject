using ASPNETCOREBlogProject.Areas.Admin.Models;
using BlogProject1.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASPNETCOREBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<WriterRole> _roleManager;
        private readonly UserManager<WriterUser> _userManager;

        public AdminRoleController(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                WriterRole role = new WriterRole
                {
                    Name = model.Name
                };

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            value.Name = model.Name;
            value.Id = model.Id;
            var result = await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        //{
        //    var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();

        //    values.Name = model.Name;
        //    var result = await _roleManager.UpdateAsync(values);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        //[HttpGet]
        //public async Task<IActionResult> AssignRole(int id)
        //{
        //    var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
        //    var roles = _roleManager.Roles.ToList();
        //    TempData["UserId"] = user.Id;
        //    var userRoles = await _userManager.GetRolesAsync(user);
        //    List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
        //    foreach (var role in roles)
        //    {
        //        RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
        //        roleAssignViewModel.RoleId = role.Id;
        //        roleAssignViewModel.Name = role.Name;
        //        roleAssignViewModel.Exists = userRoles.Contains(role.Name);
        //        model.Add(roleAssignViewModel);
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        //{
        //    var userId = (int)TempData["UserId"];
        //    var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
        //    foreach (var item in model)
        //    {
        //        if (item.Exists)
        //        {
        //            await _userManager.AddToRoleAsync(user, item.Name);
        //        }
        //        else
        //        {
        //            await _userManager.RemoveFromRoleAsync(user, item.Name);
        //        }
        //    }
        //    return RedirectToAction("UserRoleList");
        //}
        public async Task<IActionResult> AssignRole(string id)
        {
            WriterUser user = await _userManager.FindByIdAsync(id);
            List<WriterRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                Exists = userRoles.Contains(role.Name),
                RoleId = role.Id,
                Name = role.Name
            }));

            return View(assignRoles);
        }
        [HttpPost]
        public async Task<ActionResult> AssignRole(List<RoleAssignViewModel> modelList, string id)
        {
            WriterUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.Exists)
                    await _userManager.AddToRoleAsync(user, role.Name);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
            return RedirectToAction("UserRoleList");
        }



    }
}
