using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.User.Contracts.AppServices;
using App.EndPoint.ShopUi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
    //    private readonly IAppUserManager _userManager;
    //    private readonly IAppRoleManager _appRoleManager;
    //    private readonly IConverting _converting;
    //    private readonly IOrderAppService _orderAppService;

    //    public UserProfileController(IAppUserManager userManager
    //        , IAppRoleManager appRoleManager
    //        , IConverting converting
    //        ,IOrderAppService orderAppService)
    //    {
    //        _userManager = userManager;

    //        _appRoleManager = appRoleManager;
    //        _converting = converting;
    //        _orderAppService = orderAppService;
    //    }
    //    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    //    {
    //        var userInfo = User.Identity;
    //        var user = User
    //        return View();
    //    }
    //    public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
    //         public async Task<IActionResult> Update(UpdateBuyerProfileVM model, CancellationToken cancellationToken)
    }
}
