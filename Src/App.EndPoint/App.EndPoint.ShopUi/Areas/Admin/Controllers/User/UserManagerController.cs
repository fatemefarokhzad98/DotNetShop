using App.Domain.AppServices.User;
using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Dtos;
using App.Domain.Core.User.Entities;
using App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User;
using App.EndPoint.ShopUi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    [Area("Admin")]
    public class UserManagerController : Controller
    {
        private readonly IAppRoleManager _appRoleManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IConverting _converting;

        public UserManagerController(IAppUserManager appUserManager
            ,IAppRoleManager appRoleManager
            ,IConverting converting )
         {
                _appRoleManager = appRoleManager;
                _appUserManager = appUserManager;
                  _converting = converting;

        }
        public IActionResult SearchUser()
        {
            



            return View();
        }
        public async Task< IActionResult> ReadUser()
        {
           
           var user= await _appUserManager.GetAllUserWithRoles();
            var viewModel = user.Select(u => new UserManagerViewModel()
            {
                AccessFailedCount = u.AccessFailedCount,
                BrithDay = u.BrithDay,
                Email = u.Email,
                EmailConfirmed = u.EmailConfirmed,
                FirstName = u.FirstName,
                Id = u.Id,
                IsActive = u.IsActive,
                LastName = u.LastName,
                LastVisitDate = u.LastVisitDate,
                LockOutEnabled = u.LockOutEnabled,
                LockOutEnd = u.LockOutEnd,
                PhonNumberConfirmed = u.PhonNumberConfirmed,
                ProfileImgUrl = u.ProfileImgUrl,
                RigesterDate = u.RigesterDate,
                TwoFactorEnabled = u.TwoFactorEnabled,
                UserName = u.UserName,
                PhonNumber=u.PhonNumber,
                Roles = u.Roles
            }).ToList();


            return View(viewModel);


        }
        public async Task<IActionResult> DetailsUser(int id)
        {
                var model = await _appUserManager.GetUserWithRolesById(id);
                if (model==null)
                {
                    return NotFound();
                }
            var viewModel = new UserManagerViewModel()
            {
                
                 Email=model.Email,
                 FirstName=model.FirstName,
                 Id=model.Id,
                 PhonNumber=model.PhonNumber,
                 LastName=model.LastName,
                 ProfileImgUrl=model.ProfileImgUrl,
                 UserName=model.UserName,
                 Roles = model.Roles,
                 EmailConfirmed=model.EmailConfirmed,
                 AccessFailedCount=model.AccessFailedCount,
                 IsActive=model.IsActive,
                 LastVisitDate = model.LastVisitDate,
                 TwoFactorEnabled=model.TwoFactorEnabled,
                 PhonNumberConfirmed=model.PhonNumberConfirmed,
                 RigesterDate=model.RigesterDate,
                 LockOutEnd=model.LockOutEnd,
                 BrithDay=model.BrithDay,
                 LockOutEnabled=model.LockOutEnabled
                 
            };

                return View(viewModel);
           
            

        }
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
           
                var model = await _appUserManager.GetUserWithRolesById(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new UserManagerViewModel()
                {
                    BrithDatePersian = _converting.ConvertMiladiToShamsi((DateTime)model.BrithDay, "YYYY/MM/DD"),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Id = model.Id,
                    PhonNumber = model.PhonNumber,
                    LastName = model.LastName,
                    ProfileImgUrl = model.ProfileImgUrl,
                    UserName = model.UserName,
                    Roles = model.Roles,
                    EmailConfirmed=model.EmailConfirmed,
                    AccessFailedCount=model.AccessFailedCount,
                    LockOutEnabled=model.LockOutEnabled,
                    IsActive=model.IsActive,
                     LastVisitDate=model.LastVisitDate,
                       LockOutEnd=model.LockOutEnd,
                        PhonNumberConfirmed=model.PhonNumberConfirmed,
                        RigesterDate=model.RigesterDate,
                        TwoFactorEnabled=model.TwoFactorEnabled

                };
                ViewBag.Roles = _appRoleManager.GetAllRoles();
               
                return View(viewModel);
            }

        }
        [HttpPost]
       
        public async Task<IActionResult> EditUser(UserManagerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _appUserManager.FindByIdAsync(model.Id +string.Empty);
                    
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                     
                    IdentityResult result;
                    var recentRoles = await _appUserManager.GetRolesAsync(user);
                    var deleteRoles= recentRoles.Except(model.Roles);
                    var addRoles= model.Roles.Except(recentRoles);
                   result= await _appUserManager.RemoveFromRolesAsync(user, deleteRoles);
                    if (result.Succeeded)
                    {
                        result = await _appUserManager.AddToRolesAsync(user, addRoles);
                        if (result.Succeeded)
                        {

                            user.FirstName = model.FirstName;
                            user.LastName = model.LastName;
                            user.UserName = model.UserName;
                            user.ProfileImgUrl = model.ProfileImgUrl;
                            user.Email = model.Email;
                            if (model.BrithDay!=null)
                            {
                            user.BrithDay = _converting.ConvertShamsiToMiladi(model.BrithDatePersian);
                            }
                            user.PhoneNumber = model.PhonNumber;


                            result = await _appUserManager.UpdateAsync(user);
                            if (result.Succeeded)
                            {
                                ViewBag.AlertSuccess = "ذخیره تغییرات با موفقیت انجام شد";
                            }

                        }
                             

                    }
                    if (result!=null)
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);

                        }

                    }
                }
                

            }
            ViewBag.Roles = _appRoleManager.GetAllRoles();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> RemoveUser(int id)
        {

            var model = await _appUserManager.FindByIdAsync(id + string.Empty);
            if (model == null)

                return NotFound();


            else
            {
                

               
                var viewModel = new UserManagerViewModel()
                {
                   
                    BrithDatePersian = _converting.ConvertMiladiToShamsi((DateTime)model.BrithDay, "YYYY/MM/DD"),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhonNumber = model.PhoneNumber,
                    ProfileImgUrl = model.ProfileImgUrl,
                    Roles = await _appUserManager.GetRolesAsync(model),
                    UserName = model.UserName,
                    TwoFactorEnabled = model.TwoFactorEnabled,
                    AccessFailedCount = model.AccessFailedCount,
                    EmailConfirmed = model.EmailConfirmed,
                    IsActive = model.IsActive,
                    Id = model.Id,
                    LastVisitDate = model.LastVisitDate,
                    LockOutEnabled = model.LockoutEnabled,
                    LockOutEnd = model.LockoutEnd,
                    PhonNumberConfirmed = model.PhoneNumberConfirmed,
                    RigesterDate = model.RigesterDate
                       
                };
                    return View(viewModel);
                
               
               
            }
      
        }
        [HttpPost]
        [ActionName("RemoveUser")]
        public async Task<IActionResult> RemoveUser(UserManagerViewModel model)
        {
            var user = await _appUserManager.FindByIdAsync(model.Id + string.Empty);
            if (user==null)
            {
                return NotFound();
            }
            else
            {
                var result= await _appUserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ReadUser");

                }
                else
                {
                    ViewBag.AlertError = "درحدف اطلاعات خطایی رخ داده است";
                    return View(model);

                }
            }
         }
        [HttpPost]
     
        public async Task<IActionResult> GhangeLockOutEnable(int id,bool status)
        {
            var user = await _appUserManager.FindByIdAsync(id + string.Empty);
            if (user==null)
            {
                return NotFound();
            }
            else
            {
                await _appUserManager.SetLockoutEnabledAsync(user, status);
                return RedirectToAction("DetailsUser", new { id = user.Id });
            }

        }
        [HttpPost]
     
        public async Task<IActionResult> LockUserAccount(int id)
        {
            var user = await _appUserManager.FindByIdAsync(id + string.Empty);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                await _appUserManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddMinutes(20));
                return RedirectToAction("DetailsUser", new { id = user.Id });
            }

        }
        [HttpPost]
       
        public async Task<IActionResult> UnLockUserAccount(int id)
        {
            var user = await _appUserManager.FindByIdAsync(id + string.Empty);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                await _appUserManager.SetLockoutEndDateAsync(user,null);
                return RedirectToAction("DetailsUser", new { id = user.Id });
            }

        }
    }
    
}