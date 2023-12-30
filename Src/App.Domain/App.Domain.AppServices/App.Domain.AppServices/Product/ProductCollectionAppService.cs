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
    public class ProductCollectionAppService: IProductCollectionAppService
    {
        private readonly IProductCollectionService IProductCollectionService;

        public ProductCollectionAppService(IProductCollectionService productCollectionService)
        {
            IProductCollectionService = productCollectionService;

        }

        public Task<List<ProductBriefDto>?> GetCollectionWithProduct(int? id, string? name)
        {
            throw new NotImplementedException();
        }
    }
}
