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
    public class OrderDetailService: IOrderDetailService
    {
        private readonly IOrderDetailCommandRepository _orderDetailCommandRepository;

        public OrderDetailService(IOrderDetailCommandRepository orderDetailCommandRepository)
        {
            _orderDetailCommandRepository = orderDetailCommandRepository;
        }

     
        public Task RemoveCountOrderDetail(int OrderDetailId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

      
    }
}
