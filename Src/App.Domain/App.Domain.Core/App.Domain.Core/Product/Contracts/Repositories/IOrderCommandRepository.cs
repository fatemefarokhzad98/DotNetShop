using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IOrderCommandRepository
    {
        Task<int> RemoveOrder(int id, CancellationToken cancellationToken);
        Task<int> CreateOrder(int productId, int currentUserId, CancellationToken cancellationToken);
    }
}
