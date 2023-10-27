
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
                RecentRoleName=x.RoleName
                

            }).ToList().ToPagedList(page ?? 1, 5);


            return View(result);
        }
        [HttpGet]
        public IActionResult CreateRoles()
        {
           



            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateRoles(RolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(model.RoleName))
                {
                    ViewBag.Eroor = "خطا!این نقش وجود دارد";
                }
                
                var result = await _roleManager.CreateAsync(new AppRole(model.RoleName,model.RoleDescription));
          
                if (result.Succeeded)
                {
                   

                    ViewBag.successfull = "اطلاعات با موفقیت ذخیره شد";
                    return RedirectToAction("ReadRoles");
                }
                ViewBag.Error = "خطا در ذخیره نقش رخ داده است";
                return View();

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
                RoleName =role.Name

            };
         

            return View(result);
        }
        [HttpPost]
        public async Task< IActionResult> UpdateRoles(RolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(model.RoleName)&& model.RoleName!=model.RecentRoleName  )
                {
                    ViewBag.Error = "خطا!این نقش وجود دارد";

                }
              var result= await _roleManager.UpdateAsync(new AppRole
                {
                     Name=model.RoleName,
                     Description=model.RoleDescription
                });
                if (result.Succeeded)
                {
                    ViewBag.successfull = "اطلاعات با موفقیت ذخیره شد.";
                    return RedirectToAction("ReadRoles");
                }
               
                

            }

            ViewBag.Error= "خطایی در ذخیره اطلاعات رخ داد است";


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
