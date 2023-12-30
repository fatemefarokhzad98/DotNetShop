using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IOrderDetailAppService
    {
        Task RemoveCountOrderDetail(int OrderDetailId, CancellationToken cancellationToken);
      
    }
}
