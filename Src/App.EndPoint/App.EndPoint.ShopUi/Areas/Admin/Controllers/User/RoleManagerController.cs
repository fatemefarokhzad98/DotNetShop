
using App.Domain.AppServices.User;
using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Entities;
using App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    [Area("Admin")]
    public class RoleManagerController : Controller
    {
        private readonly IAppRoleManager _roleManager;
        public RoleManagerController(IAppRoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        public  IActionResult ReadRoles(int? page)
        {
            var roleDto = _roleManager.GetAllRolesAndCountUser(); 
            var result=roleDto.Select(x=>new RolesViewModel
            {
                RoleId=x.RoleId,
                RoleName=x.RoleName,
                RoleDescription=x.RoleDescription,
                CountUser=x.CountUser,
            
            }).ToList().ToPagedList(page ?? 1, 5);

            return View(result);
        }
        [HttpGet]
        public IActionResult CreateRoles()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        
        public async Task <IActionResult> CreateRoles(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new AppRole(model.RoleName,model.RoleDescription));
          
                if (result.Succeeded)
                {
                    return RedirectToAction("ReadRoles");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public async Task< IActionResult> UpdateRoles(int Id)
        {
       
           var role= await _roleManager.FindByIdAsync(Id+string.Empty);
            if (role is null)
            {
                return NotFound();

            }
            var result = new RolesViewModel
            {
                RoleDescription=role.Description,
                RoleName =role.Name,
                 RoleId=role.Id
            };
            return View(result);
        }
        [HttpPost]
        public async Task< IActionResult> UpdateRoles(RolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId + string.Empty);
                if (role == null)
                    return NotFound();
                    role.Name = model.RoleName;
                    role.Description = model.RoleDescription;
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        ViewBag.Success = "اطلاعات با موفقیت ذخیره شد.";
                        return RedirectToAction("ReadRoles");
                    }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
         }
        [HttpGet]
        public async Task<IActionResult> RemoveRoles(int Id)
        {
            var rolemodel = await _roleManager.FindByIdAsync(Id+string.Empty);
            if (rolemodel == null)
            {
                return NotFound();

            }
          var result=  await _roleManager.DeleteAsync(rolemodel);
            if (result.Succeeded)
            {

                return RedirectToAction("ReadRoles");
            }
           

            return RedirectToAction("ReadRoles");
        }



    }
}
