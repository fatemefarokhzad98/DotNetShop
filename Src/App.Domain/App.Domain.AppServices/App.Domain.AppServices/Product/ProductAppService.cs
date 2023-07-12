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

        public async Task<ProductDto?> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
                throw new Exception();
            return product;
       
        }

        public async Task<ProductDto?> GetProduct(string name)
        {
            var product = await _productService.GetProduct(name);
            if (product == null)
                throw new Exception();
            return product;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        public async Task<int> InsertProduct(ProductInsertDto product)
        {
            await _productSurnessService.EnsureModelIsNotExist(product.Name);
            return await _productService.InsertProduct(product);
        }

        public async Task<ProductDto> RemoveProduct(int id)
        {
            await _productSurnessService.EnsureModelIsExist(id);
            return await _productService.RemoveProduct(id);
        }

        public async Task<int> UpdateProduct(ProductDto product)
        {
            await _productSurnessService.EnSureModelIsExist(product.Name);
            return await _productService.UpdateProduct(product);

        }
    }
}
