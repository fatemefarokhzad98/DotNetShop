using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult List(int? categori,string? keyword)
        {

            return View();
        }
    }
}
