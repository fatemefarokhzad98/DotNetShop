using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers.ProductController
{
    public class ColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
