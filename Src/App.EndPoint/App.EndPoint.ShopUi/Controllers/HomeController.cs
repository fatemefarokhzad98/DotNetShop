using App.Domain.Core.Identity;
using App.EndPoint.ShopUi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoint.ShopUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public HomeController(ILogger<HomeController> logger
            ,UserManager<IdentityUser<int>> userManager
            ,RoleManager<AppRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task< IActionResult> SetData()
        {
            //var adminrole = await _roleManager.CreateAsync(new AppRole( "AdminRole"));
            //var CustomerRole = await _roleManager.CreateAsync(new AppRole("CustomerRole"));
            //var adminuserresult = await _userManager.CreateAsync(new IdentityUser<int>("Admin"));
            //if (adminuserresult.Succeeded)
            //{
            //    var adminuser = await _userManager.FindByNameAsync("Admin");
            //    await _userManager.AddToRoleAsync(adminuser, "AdminRole");


            //}
            //var testuserresult = await _userManager.CreateAsync(new IdentityUser<int>("test"));
            //if (testuserresult.Succeeded)
            //{
            //    var  testuser = await _userManager.FindByNameAsync("test");

            //    await _userManager.AddToRoleAsync(testuser,"CustomerRole");


            //}



            return View();
        }
    }
}