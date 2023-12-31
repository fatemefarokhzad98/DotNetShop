using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.User.Contracts.AppServices;
using App.EndPoint.ShopUi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoint.ShopUi.Component
{
    public class CartComponent:ViewComponent
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IOrderAppService _orderAppService;

        
        public CartComponent(IOrderAppService orderAppService,IAppUserManager appUserManager  )
        {
            _appUserManager = appUserManager;
            _orderAppService = orderAppService;

        }
        
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            List<ShowCartViewModel> _list = new List<ShowCartViewModel>();


            if (User.Identity.IsAuthenticated)
            {
                var userInfoId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                int userId = int.Parse(userInfoId);

             var cartDto=  await _orderAppService.GetOrderByUserID(userId, cancellationToken);

                if (cartDto == null)
                    return View( _list);
                var viewModel = cartDto.Select(x => new ShowCartViewModel()
                {
                    ProductName = x.ProductName,
                    ImageName = $"ProductFile/{x.ImageName}",
                    Count = x.Count,

                }).ToList();

                return View( viewModel);
            }
            return View(_list);
        }

    }
}
