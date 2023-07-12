using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductCommandRepository
    {
        Task<int> InsertProduct(ProductInsertDto product);
        Task<ProductDto> RemoveProduct(int id);
        Task<int> UpdateProduct(ProductDto product);
    }
}
