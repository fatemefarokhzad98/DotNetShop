using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        Task<ProductReadDto?> GetProduct(int id);
        Task<List<ProductReadDto>?> GetProduct(string name);
        Task<List<ProductReadDto>> GetProducts();
        Task<List<ProductBriefDto>>? Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId);
        Task<int> InsertProduct(ProductInsertDto product);
        Task<int> RemoveProduct(int id, string userRemoveName);
        Task<int> UpdateProduct(ProductDto product);


    }
}
