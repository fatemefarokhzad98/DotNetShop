using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class OrderSurnessService: IOrderSurnessService
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public OrderSurnessService(IOrderQueryRepository orderQueryRepository  )
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public Task EnsureModelIsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task EnsureModelIsNotExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
