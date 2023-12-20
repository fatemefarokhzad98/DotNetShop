using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Entities;
using App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User;
using App.EndPoint.ShopUi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    [Area("Admin")]
    public class AcountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IAppRoleManager _appRoleManager;

        public AcountController(UserManager<AppUser> userManager,IAppRoleManager appRoleManager)
        {
            _userManager=userManager;
          
            _appRoleManager= appRoleManager;
        }
        public IActionResult Index( string Msg)
        {
            if (Msg == "Success")
            {
                ViewBag.Alert = "عضویت با موفقیت انجام شد.";
            }
            return View();
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            var roles = _appRoleManager.GetAllRoles();
            ViewBag.Roles = new SelectList(roles,"Id","Name");

            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Register(AcountViewModel model )
        {
            //AppRole
            //string ImageBase64;
            //using (var ms = new MemoryStream())
            //{
            //    Image.CopyTo(ms);
            //    byte[] FileBytes = ms.ToArray();

            //    ImageBase64 = Convert.ToBase64String(FileBytes);
            //}
            var allroles = _appRoleManager.GetAllRoles();
            ICollection<AppRoleUser> appRoles = new Collection<AppRoleUser>();



            foreach (var item in model.Roles)
            {
                var seletRole = allroles.FirstOrDefault(x => x.Id.Equals(item));
                if (seletRole != null)
                {
                    var roleUser = new AppRoleUser();
                    roleUser.Role = seletRole;
                    appRoles.Add(roleUser);
                }
            }
            

            //*Resolve
           
            
          
            
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.Name,
                    LastName = model.Family,
                    RigesterDate = DateTime.Now,
                    IsActive = true,
                    BrithDay = Converting.PersianDateStringToDateTime(model.BrithDate),
                    
                    

                };

                user.Roles = appRoles;


                  var result = await _userManager.CreateAsync(user,model.PassWord);
                if (result.Succeeded)
                {
                  
                    return LocalRedirect("~/Admin/Acount/Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }


            }
        
            var roles = _appRoleManager.GetAllRoles();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return View(model);
        }

    }
}
