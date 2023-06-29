using App.Domain.Core.BaseData.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
