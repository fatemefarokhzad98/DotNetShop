using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers.ProductController
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
