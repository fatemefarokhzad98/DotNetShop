﻿


using App.Domain.Core.BaseData.Contracts.AppServices;

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
        public async Task< IActionResult> UpdateBrand(BrandOutPutViewModel brand )
        {

            await _brandAppService.UpdateBrand(brand.Id,brand.DisPlayOrder,brand.Name);


            return RedirectToAction("ReadBrand");
           


        }
        [HttpGet]
        public async Task< IActionResult> UpdateBrand(int id)
        {
            var brand = await _brandAppService.GetBrand(id);
            BrandOutPutViewModel brandviewmodel = new()
            {
                Id = id,
                Name=brand.Name,
              
                DisPlayOrder=brand.DisplayOrder

            

            };


            return View(brandviewmodel);



        }
        public async Task< IActionResult> ReadBrand()
        {
          var brands= await _brandAppService.GetBrands();
            var brandsModel = brands.Select(b => new BrandInPutViewModel()
            {
               Id=b.Id,

                Name = b.Name,
                DisPlayOrder = b.DisplayOrder,
                CreationDate=b.CreationDate,
              



            }).ToList();
            return View(brandsModel);

        }
        public async Task< IActionResult> RemoveBrand(int Id)
        {
         await   _brandAppService.RemoveBrand(Id);
            return RedirectToAction("ReadBrand");

        }
        [HttpGet]
        public IActionResult InsertBrand()
        {
            return View();

        }
        [HttpPost]
        public async Task< IActionResult> InsertBrand(BrandOutPutViewModel brand)
        {
           await _brandAppService.SetBrand(brand.DisPlayOrder,brand.Name);
            return RedirectToAction("ReadBrand");

        }





    }
}
