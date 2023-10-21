

using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductService:IProductService
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepsitory;

        public ProductService(IProductCommandRepository productCommandRepository,IProductQueryRepository productQueryRepsitory)
        {
           

            _productCommandRepository = productCommandRepository;
            _productQueryRepsitory = productQueryRepsitory;

        }

        public async Task<ProductDto?> GetProduct(int id)
        {
           return await _productQueryRepsitory.GetProduct(id);

        }

        public async Task<ProductDto?> GetProduct(string name)
        {
            return await _productQueryRepsitory.GetProduct(name);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _productQueryRepsitory.GetProducts();
        }

        public Task<List<ProductBriefDto>> GetProductsList(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertProduct(ProductInsertDto product)
        {
           return await _productCommandRepository.InsertProduct(product);

        }

        public async Task<ProductDto> RemoveProduct(int id)
        {
            return await _productCommandRepository.RemoveProduct(id);
        }

        public async Task<int> UpdateProduct(ProductDto product)
        {
            return await _productCommandRepository.UpdateProduct(product);
        }
    }
}
