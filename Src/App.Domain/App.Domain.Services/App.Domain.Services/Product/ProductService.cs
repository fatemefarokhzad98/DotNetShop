

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

        public async Task<ProductReadDto?> GetProduct(int id)
        {
           var product= await _productQueryRepsitory.GetProduct(id);
           
            return product;

        }

        public async Task<List<ProductReadDto>?> GetProduct(string name)
        {
            var product= await _productQueryRepsitory.GetProduct(name);
           
            return product;
        }

        public async Task<List<ProductReadDto>> GetProducts()
        {

            var product= await _productQueryRepsitory.GetProducts();
            
            return product;
        }

      

        public async Task<int> InsertProduct(ProductInsertDto product)
        {
           return await _productCommandRepository.InsertProduct(product);

        }

        public async Task<int> RemoveProduct(int id, string userRemoveName)
        {
            return await _productCommandRepository.RemoveProduct(id,userRemoveName);
        }

        public async Task<int> UpdateProduct(ProductDto product)
        {
            return await _productCommandRepository.UpdateProduct(product);
        }
        public async Task<List<ProductBriefDto>>? Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId)
        {
         var products= await  _productQueryRepsitory.Search(categoryId, keyWord, minPrice,maxPrice, brandId)!;
            if (products==null)
            {
                throw new Exception();
            }
            return products;
        }

    }
}
