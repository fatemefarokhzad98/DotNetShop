using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    public class UserManagementController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
       
        public UserManagementController(UserManager<IdentityUser<int>> userManager
            , RoleManager<IdentityRole<int>> roleManager)
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
