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
    public class ProductCollectionService: IProductCollectionService
    {
        private readonly IProductCollectionQueryRepository _productCollectionQueryRepository;

        public ProductCollectionService(IProductCollectionQueryRepository productCollectionQueryRepository)
        {
            _productCollectionQueryRepository = productCollectionQueryRepository;
        }

        public Task<List<ProductBriefDto>?> GetCollectionWithProduct(int? id, string? name)
        {
            throw new NotImplementedException();
        }
    }
}
