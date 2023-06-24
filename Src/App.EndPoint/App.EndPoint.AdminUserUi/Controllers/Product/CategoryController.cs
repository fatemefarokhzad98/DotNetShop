using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.Product
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
