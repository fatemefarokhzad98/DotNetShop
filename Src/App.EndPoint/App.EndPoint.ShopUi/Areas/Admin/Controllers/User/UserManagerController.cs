using App.Domain.AppServices.User;
using App.Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    public class UserManagerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppRoleManager _roleManager;
       
        public UserManagerController(UserManager<AppUser> userManager
            , AppRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager= roleManager;

        }
        public IActionResult SearchUser()
        {
            



            return View();
        }

    }
}
