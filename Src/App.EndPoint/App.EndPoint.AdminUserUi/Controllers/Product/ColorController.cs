using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.Product
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
