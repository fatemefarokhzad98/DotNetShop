using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
