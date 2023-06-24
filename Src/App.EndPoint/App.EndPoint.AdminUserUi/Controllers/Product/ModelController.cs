using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.Product
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
