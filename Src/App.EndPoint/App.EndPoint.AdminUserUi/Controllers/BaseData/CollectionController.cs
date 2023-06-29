using App.Domain.Core.BaseData.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class CollectionController : Controller
    {
        private readonly ICollectionAppService _coolectionAppService;
        public CollectionController(ICollectionAppService coolectionAppService)
        {
            _coolectionAppService = coolectionAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
