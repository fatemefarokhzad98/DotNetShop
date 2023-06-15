using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Read()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
