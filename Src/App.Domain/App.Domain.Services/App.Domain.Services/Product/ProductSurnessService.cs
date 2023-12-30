using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductSurnessService : IProductSurnessService
    {
       
        private readonly IProductQueryRepository _productQueryRepsitory;

        public ProductSurnessService( IProductQueryRepository productQueryRepsitory)
        {


           
            _productQueryRepsitory = productQueryRepsitory;

        }
        public async Task EnsureModelIsExist(int id)
        {
            var product = await _productQueryRepsitory.GetProduct(id);
            if (product == null)
                throw new Exception();
        }


        public async Task EnsureModelIsNotExist(int id)
        {
            var product = await _productQueryRepsitory.GetProduct(id);
            if (product != null)
                throw new Exception();

        }

      
        
    }
}
