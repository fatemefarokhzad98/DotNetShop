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

        Task<ProductDto?> GetProduct(int id);
        Task<ProductDto?> GetProduct(string name);
        Task<List<ProductDto>> GetProducts();

    }
}
