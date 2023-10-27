﻿using App.Domain.Core.User.Entities;
using App.EndPoint.ShopUi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser>  _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
              
                var result= await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "خطا در لاگین");

                }
            }

            return View(model);
        }
        public IActionResult ModalLogin()
        {
            return View();
        }

    
        [HttpPost]
        public  async Task< IActionResult> ModalLogin(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "خطا در لاگین");

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
                    UserName=model.Email,
                    Email=model.Email,
                    PhoneNumber=model.Mobile,
              
                };
           var result=await _userManager.CreateAsync(user,model.Password);       
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index");
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
        public async  Task <IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            

            return RedirectToAction("Login");
        }

    }
}
