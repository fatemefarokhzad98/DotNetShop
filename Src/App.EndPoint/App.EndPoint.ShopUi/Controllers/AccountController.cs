using App.Domain.AppServices.User;
using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Entities;
using App.EndPoint.ShopUi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.ShopUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserManager _userManager;
        private readonly SignInManager<AppUser>  _signInManager;
        private readonly IAppRoleManager _appRoleManager;

        public AccountController(IAppUserManager userManager
            , SignInManager<AppUser> signInManager
            ,IAppRoleManager appRoleManager)
            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appRoleManager = appRoleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
      
        public async Task< IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
              
                var result= await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "حساب کاربری شما به مدت 20دقیقه به دلیل تلاش های ناموفق قفل شده است");
                    return View();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری یاکلمه عبور نادرست است");

                }
            }

            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
    
        public async Task< IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user=new AppUser
                {
                    UserName=model.UserName,
                    PhoneNumber=model.Mobile,
                    RigesterDate=DateTime.Now,
                    IsActive=true,
                  
                };

                  IdentityResult result=await _userManager.CreateAsync(user,model.Password);       
                if (result.Succeeded)
                {
                    var role = await _appRoleManager.FindByNameAsync("کاربر");
                    if (role == null)
                    
                        await _appRoleManager.CreateAsync(new AppRole("کاربر"));
                        result = await _userManager.AddToRoleAsync(user, "کاربر");

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index");
                    }

                    
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }


            }
            return View(model);
        }
        [HttpPost]
    
        public async  Task <IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            
            
            return RedirectToAction("Index","Home");
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SetData()
        {

            var user = new AppUser();
            user.UserName = "FatemeFarokhzad98";
            user.FirstName = "زهرا";
            user.LastName = "فرخزاد";
            user.PhoneNumber = "09109560198";
            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, "ادمین");
            await _userManager.AddPasswordAsync(user,"123456789AAFF@");
            
          

            return View();
        }


    }

}