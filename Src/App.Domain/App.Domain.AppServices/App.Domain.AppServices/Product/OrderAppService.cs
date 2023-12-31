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
    public class OrderAppService: IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderSurnessService _orderSurnessService;

        public OrderAppService(IOrderService orderService , IOrderSurnessService  orderSurnessService )
        {
            _orderService = orderService;
            _orderSurnessService = orderSurnessService;

        }

        public async Task<int> CreateOrder(int productId, int currentUserId, CancellationToken cancellationToken)
        {
           return await _orderService.CreateOrder(productId, currentUserId, cancellationToken);
        }

        public Task<List<OrderForOrderDetailDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OrderForOrderDetailDto> GetByOrderId(int orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderForOrderDetailDto>?> GetOrderByUserIDForAdmin(int buyerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<List<OrderDetailForOrderDto>?> GetOrderByUserID(int currentUserId, CancellationToken cancellationToken)
        {
            return await _orderService.GetOrderByUserID(currentUserId, cancellationToken);
        }
        public Task<int> RemoveOrder(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
