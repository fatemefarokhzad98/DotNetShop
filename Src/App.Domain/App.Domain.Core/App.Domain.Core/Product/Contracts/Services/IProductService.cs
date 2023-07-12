using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductService
    {
        Task<ProductDto?> GetProduct(int id);
        Task<ProductDto?> GetProduct(string name);
        Task<List<ProductDto>> GetProducts();
        Task<int> InsertProduct(ProductInsertDto product);
        Task<ProductDto> RemoveProduct(int id);
        Task<int> UpdateProduct(ProductDto product);
    }
}
