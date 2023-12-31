
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.User.Contracts.AppServices;
using App.EndPoint.ShopUi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize]
        public async Task <IActionResult> AddToCart(int id,CancellationToken cancellationToken)
        {
            var userInfoId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int UserId = int.Parse(userInfoId);
            await _orderAppService.CreateOrder(id, UserId,cancellationToken);
            return RedirectToAction("ReadProduct","Search");

        }
        public async Task<IActionResult> ShowOrder(CancellationToken cancellationToken)
        {
            var userInfoId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int UserId = int.Parse(userInfoId);
          var orderDto=  await _orderAppService.GetOrderByUserID(UserId, cancellationToken);
            var orderViewModel = orderDto.Select(x => new ShowOrderViewModel()
            {
                OrderDetailId=x.Id,
                Count=x.Count,
                ImageName=$"ProductFile/{x.ImageName}",
                Price=x.Price,
                ProductName=x.ProductName,
                SiteComision=x.SiteCommission,
                 Sum=x.TotalAmount
                
            }).ToList();
            return View (orderViewModel);

        }
    }
}
