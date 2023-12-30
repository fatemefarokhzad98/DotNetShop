using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IOrderQueryRepository
    {

        Task<List<OrderForOrderDetailDto>?> GetOrderByUserIDForAdmin(int buyerId, CancellationToken cancellationToken);
        Task<List<OrderForOrderDetailDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderForOrderDetailDto> GetByOrderId(int orderId, CancellationToken cancellationToken);
    }
}
