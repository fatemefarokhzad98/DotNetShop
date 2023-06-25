


using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;


   
namespace App.EndPoint.AdminUserUi.Controllers.Product
{
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;
        public BrandController(IBrandAppService brandAppService)
        {

            _brandAppService = brandAppService;
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            _brandAppService.UpdateBrand(brand);
            return RedirectToAction("Read");


        }
        [HttpGet]
        public IActionResult UpdateBrand(int Id)
        {
          var brand= _brandAppService.GetId(Id);
            return View(brand);



        }
        public IActionResult ReadBrand()
        {
          var brands=  _productAppService.GetAllBrnds();
            return View(brands);

        }
        public IActionResult RemoveBrand(int Id)
        {
            _productAppService.RemoveBrand(Id);
            return RedirectToAction("Read");

        }
        [HttpGet]
        public IActionResult InsertBrand()
        {
            return View();

        }
        [HttpPost]
        public IActionResult InsertBrand(Brand brand)
        {
          
            return RedirectToAction("Read");

        }





    }
}
