using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.User.Contracts.AppServices;
using App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.Product;
using App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList;


namespace App.EndPoint.ShopUi.Area.Admin.Controllers.Product

{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IBrandAppService _brandAppService;
        private readonly IModelAppService _modelAppService;
        private readonly IAppUserManager _appUserManager ;
        private readonly IColorAppService _colorAppService;
        private readonly IStatusAppService _statusAppService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(IProductAppService productAppService
            ,ICategoryAppService categoryAppService
            ,IBrandAppService brandAppService
            ,IModelAppService modelAppService
            , IAppUserManager appUserManager
            ,IColorAppService colorAppService
            ,IStatusAppService statusAppService
            , IWebHostEnvironment hostingEnvironment)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _brandAppService = brandAppService;
            _modelAppService = modelAppService;
            _appUserManager = appUserManager;
            _colorAppService = colorAppService;
            _statusAppService = statusAppService;
            _hostingEnvironment = hostingEnvironment;


        }
        
        public async Task<IActionResult> DetailProduct(int id)
        {
            var product = await _productAppService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                DetailProductViewModel viewModel = new DetailProductViewModel()
                {
                     Id=product.Id,
                      BrandId=product.BrandId,
                       BrandName=product.BrandName,
                        CategoryId=product.CategoryId,
                         CategoryName=product.CategoryName,
                          Count=product.Count,
                         Description=product.Description,
                         UerlImage=$"~/ProductImage/{product.ImangeName}",
                         ModelId=product.ModelId,
                         ModelName=product.ModelName,
                         Name=product.Name,
                         Price=product.Price,
                          SubmitTime=product.SubmitTime,
                        
                         operatornameinsert=product.UserSubmitName,

                };
                return View(viewModel);

            }

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
                SubmitTime = p.SubmitTime,
                SubmitOperatorName = p.UserSubmitName,
                EditOperatorName = p.UserEditName


            }).ToList();

                return View(productViewModel);
            
        }
        [HttpPost]
       
        [Authorize]
        public async Task<IActionResult> UpdateProduct(ProductUpdateViewModel product)
        {
       
            if (ModelState.IsValid)
            {
                if (product.File != null)
                {
                    string FileExtension = Path.GetExtension(product.File.FileName);
                    string NewImageName = string.Concat(Guid.NewGuid().ToString(), FileExtension);
                    var path = $"{_hostingEnvironment.WebRootPath}/ProductFile/{NewImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await product.File.CopyToAsync(stream);
                    }
                    product.ImageName = NewImageName;
                }
                var colors = await _colorAppService.GetColors();

                var selectedColors = colors.Where(x => product.Colors.Contains(x.Id)).ToList();
                ProductDto productDto = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    BrandId = product.BrandId,
                  
                    CategoryId = product.CategoryId,
               
                    Count = product.Count,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsOrginal = product.IsOrginal,
                    ModelId = product.ModelId,
                 
                    Price = product.Price,
                    StatusId = product.StatusId,
                  
                     ImangeName=product.ImageName,
                     Colors=selectedColors,
                    EditUserName = User.FindFirstValue(ClaimTypes.Name)

                };
                await _productAppService.UpdateProduct(productDto);

                return RedirectToAction("ReadProduct");
            }
            ViewBag.Colors = new SelectList(await _colorAppService.GetColors(), "Id", "Name");
            ViewBag.Status = new SelectList(await _statusAppService.GetProductStatus(), "Id", "Title");
            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            return View(product);
            
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productAppService.GetProduct(id);
            var productViewModel = new ProductUpdateViewModel()
            {
                Id = id,
                Name = product.Name,
                BrandId = product.BrandId,
            
                CategoryId = product.CategoryId,
            
                Count = product.Count,
                Description = product.Description,
                IsActive = product.IsActive,
                IsOrginal = product.IsOrginal,
                ModelId = product.ModelId,
              
                Price = product.Price,
                StatusId = product.StatusId,
              
                 ImageName=product.ImangeName
                
            };

            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            ViewBag.Colors = new SelectList(await _colorAppService.GetColors(), "Id", "Name");
            ViewBag.Status = new SelectList(await _statusAppService.GetProductStatus(), "Id", "Title");
            return View(productViewModel);
        }
        [Authorize]
      
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            await _productAppService.RemoveProduct(id,user);

            return RedirectToAction("ReadProduct");
        }
        [HttpGet]
        [Authorize]
       
        public async Task<IActionResult> InsertProduct()
        {

            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            var color = await _colorAppService.GetColors();
            ViewBag.Colors = new SelectList(color, "Id", "Name");
            ViewBag.Status = new SelectList(await _statusAppService.GetProductStatus(), "Id", "Title");



            return View();
        }
        [HttpPost]
        
        [Authorize]
        public async Task<IActionResult> InsertProduct(ProductInsertViewModel product)
        {
            
            if (ModelState.IsValid)
            {
                if (product.File != null)
                {
                    string FileExtension = Path.GetExtension(product.File.FileName);
                    string NewImageName = string.Concat(Guid.NewGuid().ToString(), FileExtension);
                    var path = $"{_hostingEnvironment.WebRootPath}/ProductFile/{NewImageName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await product.File.CopyToAsync(stream);
                    }
                    product.ImageName = NewImageName;
                }

                var color = await _colorAppService.GetColors();

                var selectedColors = color.Where(x => product.Colors.Contains(x.Id)).ToList();
                ProductInsertDto productInsertDto = new()
                {
                    Name = product.Name,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Count = product.Count,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsOrginal = product.IsOrginal,
                    ModelId = product.ModelId,
                    Price = product.Price,
                    StatusId = product.StatusId,
                    SubmitOperatorName = User.FindFirstValue(ClaimTypes.Name),
                     Colors=selectedColors,
                     ImageName=product.ImageName
                   
            };
                await _productAppService.InsertProduct(productInsertDto);


                return RedirectToAction("ReadProduct");
            }
            return View(product);
        }
        

    }
}
