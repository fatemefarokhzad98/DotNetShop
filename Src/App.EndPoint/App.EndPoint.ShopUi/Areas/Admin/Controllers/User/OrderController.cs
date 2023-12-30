using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.User
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
