using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.Dashbord
{
    [Area("Admin")]
    public class DashbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
