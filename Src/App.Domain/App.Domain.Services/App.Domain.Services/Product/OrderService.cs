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
    public class OrderService: IOrderService
    {
        private readonly IOrderCommandRepository _orderCommandRepositpry;
        private readonly IOrderQueryRepository _orderQueryRepository;

        public OrderService(IOrderCommandRepository orderCommandRepositpry,IOrderQueryRepository orderQueryRepository )
        {
            _orderCommandRepositpry = orderCommandRepositpry;

            _orderQueryRepository = orderQueryRepository;
        }

        public Task<int> CreateOrder(int productId, int currentUserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public Task<int> RemoveOrder(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
