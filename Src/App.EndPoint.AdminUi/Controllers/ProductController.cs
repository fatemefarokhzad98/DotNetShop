using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Apdate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Apdate()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }
       
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Read()
        {
            return View();
        }


    }
}
