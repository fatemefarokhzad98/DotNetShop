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
    public class OrderDetailAppService : IOrderDetailAppService
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailAppService(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;

        }

       
        public Task RemoveCountOrderDetail(int OrderDetailId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
