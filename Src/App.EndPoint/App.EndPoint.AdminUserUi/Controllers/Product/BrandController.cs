

using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;


   
namespace App.EndPoint.AdminUserUi.Controllers.Product
{
    public class BrandController : Controller
    {
        private readonly IProductAppService _productAppService;
        public BrandController(IProductAppService productAppService)
        {

            _productAppService = productAppService;
        }
        [HttpPost]
        public IActionResult Update(Brand brand)
        {
            _productAppService.UpdateBrand(brand);
            return RedirectToAction("Read");


        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
          var brand=  _productAppService.GetId(Id);
            return View(brand);



        }
        public IActionResult Read()
        {
          var brands=  _productAppService.GetAllBrnds();
            return View(brands);

        }
        public IActionResult Remove(int Id)
        {
            _productAppService.RemoveBrand(Id);
            return RedirectToAction("Read");

        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Brand brand)
        {
            _productAppService.CreateBrand(brand);
            return RedirectToAction("Read");

        }





    }
}
