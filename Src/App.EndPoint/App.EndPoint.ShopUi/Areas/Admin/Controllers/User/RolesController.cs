using App.Domain.Core.Identity;
using App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RolesController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public  IActionResult ReadRoles(int? page)
        {
            var result = _roleManager.Roles.Select(p => new RolesViewModel
            {
                RoleId = p.Id,
                RoleName = p.Name,
                RoleDescription=p.Description
                


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
                var result = await _roleManager.CreateAsync(new AppRole(model.RoleName,model.RoleDescription));
          
                if (result.Succeeded)
                {
                    return RedirectToAction("ReadRoles");

                    ViewBag.errorcreate = "اطلاعات با موفقیت ذخیره شد";
                }
                ViewBag.errorcreate = "خطا در ذخیره نقش رخ داده است";
                return View(result);

            }




            return View(model);
        }
        [HttpGet]
        public async Task< IActionResult> UpdateRoles(int modelId)
        {
           var result= await _roleManager.FindByIdAsync(string.Empty+modelId);
            if (result is null)
            {
                return NotFound();
                
            }

            return View(result);
        }
        [HttpPost]
        public async Task< IActionResult> UpdateRoles(RolesViewModel model)
        {
            if (ModelState.IsValid)
            {
               await _roleManager.UpdateAsync(new AppRole
                {
                     Name=model.RoleName,
                     Description=model.RoleDescription
                });
                ViewBag.successfull = "باموفقیت تغییر پیدا کرد";
                return RedirectToAction("ReadRoles");

            }

            ViewBag.error = "خطایی در تغییر نقش رخ داد است";


            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RemoveRoles(int modelId)
        {
            var rolemodel = await _roleManager.FindByIdAsync(string.Empty+ modelId);
            if (rolemodel == null)
            {
                return NotFound();

            }
          var result=  await _roleManager.DeleteAsync(rolemodel);
            if (result.Succeeded)
            {

                return RedirectToAction("ReadRoles");
            }
            ViewBag.errordelete = "در عملیات حذف مشکل ایجاد شده";

            return RedirectToAction("ReadRoles");
        }



    }
}
