using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IBrandSurenessService _brandSurenessService;
        public ProductAppService(IProductService productService,IBrandSurenessService brandSurenessService)
        {
            _productService = productService;

            _brandSurenessService = brandSurenessService;
        }

        

        public void CreateBrand(Brand brand)
        {
            _brandSurenessService.EnsureBrandIsNotExist(brand.Name);
            _productService.CreateBrand(brand);
        }

        public Brand? GetId(int Id)
        {
            _brandSurenessService.EnsureBrandIsExist(Id);
            var brand = GetId(Id);
            return brand;
               
        }
        public Brand? GetName(string name)
        {
            _brandSurenessService.EnSureBrandIsExist(name);
            return _productService.GetName(name);
        }

        public List<Brand> GetAllBrnds()
        {
          return _productService.GetAllBrnds();
        }

        public void RemoveBrand(int Id)
        {
            
            _productService.RemoveBrand(Id);
        }

        public void UpdateBrand(Brand brand)
        {
            
            _productService.UpdateBrand(brand);
        }
    }
}
