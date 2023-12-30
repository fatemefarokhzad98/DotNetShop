using App.Domain.Core.Product.Contracts.Repositories;
using App.Infrastructure.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.Product
{
    public class OrderDetailCommandRepository: IOrderDetailCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderDetailCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task RemoveCountOrderDetail(int OrderDetailId, CancellationToken cancellationToken)
        {
            var OrderDetail = await _appDbContext.OrderDetail.FindAsync(OrderDetailId);
            if (OrderDetail.Count > 1)
            {
                OrderDetail.Count -= 1;
                _appDbContext.Update(OrderDetail);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                var order = await _appDbContext.Order.FindAsync(OrderDetail.OrderId, cancellationToken);
                order.TotalAmount = Convert.ToInt32(_appDbContext.OrderDetail.Where(S => S.OrderId == order.Id).Select(x => x.Count * x.Price).Sum());
                order.SiteCommission = order.TotalAmount + 20000;
                _appDbContext.Update(order);
                await _appDbContext.SaveChangesAsync(cancellationToken);

            }
            else
            {
                _appDbContext.Remove(OrderDetail);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }

        }
    }
}