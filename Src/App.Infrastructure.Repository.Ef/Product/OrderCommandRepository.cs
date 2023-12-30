using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using productentity= App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Entities; 
using App.Infrastructure.DataBase.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.User.Entities;

namespace App.Infrastructure.Repository.Ef.Product
{
    public class OrderCommandRepository: IOrderCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<int> CreateOrder(int productId, int currentUserId, CancellationToken cancellationToken)
        {
          
            var order = await _appDbContext.Order.SingleOrDefaultAsync(o => o.BuyerId == currentUserId &&o.IsFinal==false,cancellationToken);
            if (order == null)
            {
                order = new Order()
                {
                   BuyerId=currentUserId,
                   CreatedAt=DateTime.Now,
                   IsDeleted=false,
                   IsFinal=false,
                   TotalAmount=0,
                   SiteCommission=0,
                 
                };
                _appDbContext.Order.Add(order);
                _appDbContext.OrderDetail.Add(new OrderDetail()
                {

                    OrderId = order.Id,
                    Count = 1,
                    Price=  _appDbContext.Product.Find(productId).Price,
                    ProductId=productId
                }) ;
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                var orderDetail = await _appDbContext.OrderDetail.SingleOrDefaultAsync(d => d.OrderId == order.Id && d.ProductId == productId,cancellationToken);
                if (orderDetail == null)
                {
                    _appDbContext.OrderDetail.Add(new OrderDetail()
                    {
                         ProductId = productId,
                         Count=1,
                         OrderId=order.Id,
                         Price=_appDbContext.Product.Find(productId).Price,
                           


                    });
                }
                else
                {
                    orderDetail.Count += 1;
                    _appDbContext.Update(orderDetail);
                }
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            order.TotalAmount = Convert.ToInt32(_appDbContext.OrderDetail.Where(S => S.OrderId == order.Id).Select(x => x.Count * x.Price).Sum());
            order.SiteCommission = order.TotalAmount + 20000;
            _appDbContext.Update(order);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return order.Id;

        }

        public async  Task<int> RemoveOrder(int id, CancellationToken cancellationToken)
        {
            var order = await _appDbContext.Order.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            order.IsDeleted=true;
            order.DeletedAt = DateTime.Now;
           await _appDbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
       





    }
}
