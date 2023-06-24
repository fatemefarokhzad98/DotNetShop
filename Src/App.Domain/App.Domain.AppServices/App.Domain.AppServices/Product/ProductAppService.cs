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
        public ProductAppService(IProductService productService)
        {
            _productService = productService;

        }

        

        public void CreateBrand(Brand brand)
        {
            _productService.CreateBrand(brand);
        }

        public Brand Exist(int Id)
        {
            return _productService.Exist(Id);
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
