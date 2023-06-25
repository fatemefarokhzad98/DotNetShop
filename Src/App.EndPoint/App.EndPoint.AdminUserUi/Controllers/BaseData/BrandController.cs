


using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using App.EndPoint.AdminUserUi.Models.ViewModels.BaseData;
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
        public IActionResult UpdateBrand(BrandOutPutViewModel brand )
        {

             _brandAppService.UpdateBrand(brand.Id,brand.DisPlayOrder,brand.Name);


            return RedirectToAction("ReadBrand");
           


        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var brand = _brandAppService.GetBrand(id);
            BrandOutPutViewModel brandInput = new BrandOutPutViewModel()
            {
                Id=id,
                Name=brand.Name,
                DisPlayOrder=brand.DisplayOrder

            };


            return View(brandInput);



        }
        public IActionResult ReadBrand()
        {
          var brands= _brandAppService.GetBrands();
            var brandsModel = brands.Select(b => new BrandOutPutViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                DisPlayOrder = b.DisplayOrder,
                CreationDate = b.CreationDate,
                IsDeleted=b.IsDeleted



            }).ToList();
            return View(brandsModel);

        }
        public IActionResult RemoveBrand(int Id)
        {
            _brandAppService.RemoveBrand(Id);
            return RedirectToAction("Read");

        }
        [HttpGet]
        public IActionResult InsertBrand()
        {
            return View();

        }
        [HttpPost]
        public IActionResult InsertBrand(BrandInPutViewModel brand)
        {
            _brandAppService.SetBrand(brand.DisPlayOrder,brand.Name);
            return RedirectToAction("ReadBrand");

        }





    }
}
