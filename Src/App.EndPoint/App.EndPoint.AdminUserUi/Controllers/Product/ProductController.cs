using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoint.AdminUserUi.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.AdminUserUi.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IBrandAppService _brandAppService;
        private readonly IModelAppService _modelAppService;

        public ProductController(IProductAppService productAppService,ICategoryAppService categoryAppService,IBrandAppService brandAppService,IModelAppService modelAppService )
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _brandAppService = brandAppService;
            _modelAppService = modelAppService;


        }
        public async Task< IActionResult> ReadProduct()
        {
            var product = await _productAppService.GetProducts();
            var productViewModel = product.Select(p => new ProductReadViewModel()
            {
                Name = p.Name,
                BrandId = p.BrandId,
                BrandName = p.BrandName,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                Count = p.Count,
                Description = p.Description,
                Id = p.Id,
                IsActive = p.IsActive,
                IsOrginal = p.IsOrginal,
                ModelId = p.ModelId,
                ModelName = p.ModelName,
                Price = p.Price,
                StatusId = p.StatusId,
                StatusName = p.StatusName,
                SubmitOperatorId = p.SubmitOperatorId,
                SubmitOperatorName = p.SubmitOperatorName,


            }).ToList();
             
            return View(productViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateViewModel product)
        {
            if (ModelState.IsValid)
            {


                ProductDto productDto = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    BrandId = product.BrandId,
                    BrandName = product.BrandName,
                    CategoryId = product.CategoryId,
                    CategoryName = product.CategoryName,
                    Count = product.Count,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsOrginal = product.IsOrginal,
                    ModelId = product.ModelId,
                    ModelName = product.ModelName,
                    Price = product.Price,
                    StatusId = product.StatusId,
                    StatusName = product.StatusName,
                    SubmitOperatorId = product.SubmitOperatorId,
                    SubmitOperatorName = product.SubmitOperatorName,

                };
                await _productAppService.UpdateProduct(productDto);

                return RedirectToAction("ReadProduct");
            }
            return View(product);
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productAppService.GetProduct(id);
            var productViewModel = new ProductUpdateViewModel()
            {
                Id = id,
                Name = product.Name,
                BrandId = product.BrandId,
                BrandName = product.BrandName,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                Count = product.Count,
                Description = product.Description,
                IsActive = product.IsActive,
                IsOrginal = product.IsOrginal,
                ModelId = product.ModelId,
                ModelName = product.ModelName,
                Price = product.Price,
                StatusId = product.StatusId,
                StatusName = product.StatusName,
                SubmitOperatorId = product.SubmitOperatorId,
                SubmitOperatorName = product.SubmitOperatorName,

            };
            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            return View(productViewModel);
        }
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productAppService.RemoveProduct(id);

            return RedirectToAction("ReadProduct");
        }
        [HttpGet]
        public async Task<IActionResult> InsertProduct()
        {

            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
           


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertProduct(ProductInsertViewModel product)
        {
            if (ModelState.IsValid)
            {


                ProductInsertDto productInsertDto = new()
                {
                    Name = product.Name,
                    BrandId = product.BrandId,
                    BrandName = product.BrandName,
                    CategoryId = product.CategoryId,
                    CategoryName = product.CategoryName,
                    Count = product.Count,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsOrginal = product.IsOrginal,
                    ModelId = product.ModelId,
                    ModelName = product.ModelName,
                    Price = product.Price,
                    StatusId = product.StatusId,
                    StatusName = product.StatusName,
                    SubmitOperatorId = product.SubmitOperatorId,
                    SubmitOperatorName = product.SubmitOperatorName,

                };
                await _productAppService.InsertProduct(productInsertDto);


                return RedirectToAction("ReadProduct");
            }
            return View(product);
        }

    }
}
