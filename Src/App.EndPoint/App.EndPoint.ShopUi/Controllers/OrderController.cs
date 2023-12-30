
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.User.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IOrderAppService _orderAppService;

        public IOrderDetailAppService _orderDetailAppService { get; }

        public OrderController(IOrderAppService orderAppService,IAppUserManager appUserManager,IOrderDetailAppService orderDetailAppService )
        {
            _appUserManager = appUserManager;
            _orderAppService = orderAppService;
            _orderDetailAppService = orderDetailAppService;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
