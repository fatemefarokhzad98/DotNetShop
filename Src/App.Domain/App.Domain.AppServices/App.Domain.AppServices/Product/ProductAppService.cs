using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService:IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IProductSurnessService _productSurnessService;

        public ProductAppService(IProductService productService,IProductSurnessService productSurnessService)
        {
            _productService = productService;
            _productSurnessService = productSurnessService;

        }

        public async Task<ProductReadDto?> GetProduct(int id)
        {
           return await _productService.GetProduct(id);
            
          
       
        }

        public async Task<List<ProductReadDto>?> GetProduct(string name)
        {
            return await _productService.GetProduct(name);
            
        }

        public async Task<List<ProductReadDto>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        public async Task<int> InsertProduct(ProductInsertDto product)
        {
           
            return await _productService.InsertProduct(product);
        }

        public async Task<int> RemoveProduct(int id, string userRemoveName)
        {
            await _productSurnessService.EnsureModelIsExist(id);
            return await _productService.RemoveProduct(id,userRemoveName);
        }

        public async Task<List<ProductBriefDto>>? Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId)
        {
           return await _productService.Search(categoryId, keyWord, minPrice, maxPrice, brandId)!;
        }

        public async Task<int> UpdateProduct(ProductDto product)
        {
           
            return await _productService.UpdateProduct(product);

        }

       
    }
}
