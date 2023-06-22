using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers.ProductController
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
