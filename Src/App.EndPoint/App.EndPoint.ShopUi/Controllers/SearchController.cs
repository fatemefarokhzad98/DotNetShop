using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.AppServices;
using App.EndPoint.ShopUi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.ShopUi.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductCollectionAppService _productCollectionAppService;
        private readonly IProductAppService _productAppService;
        private readonly IColorAppService _colorAppService;

        public SearchController(IProductCollectionAppService productCollectionAppService
           , IProductAppService productAppService
            ,IColorAppService colorAppService)
        {
            _productCollectionAppService = productCollectionAppService;
            _productAppService = productAppService;
            _colorAppService = colorAppService;
        }
        public IActionResult List()
        {

            return View();
        }
        public async Task<IActionResult> ReadProduct()
        {
            var product = await _productAppService.GetProducts();
            var vm = product.Select(x => new ShortProductViewModel()
            {
                Id=x.Id,
              
                 Name=x.Name,
                  Price=x.Price,
                   Image= $"/ProductFile/{x.ImangeName}",
                Colors = x.Colors,
                 BrandName=x.BrandName

            }).ToList();
            return View(vm);
        }

    }
}
