using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductQueryRepository
    {

        Task<ProductReadDto?> GetProduct(int id);
        Task<List<ProductReadDto>?> GetProduct(string name);
        Task<List<ProductReadDto>> GetProducts();
        Task<List<ProductBriefDto>>? Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId);



    }
}
