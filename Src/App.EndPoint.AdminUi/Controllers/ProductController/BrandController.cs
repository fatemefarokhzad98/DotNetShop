using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers.ProductController
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
