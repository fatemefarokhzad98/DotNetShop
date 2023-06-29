using App.Domain.Core.BaseData.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class ModelController : Controller
    {
        private readonly IModelAppService _modelAppService;
        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
