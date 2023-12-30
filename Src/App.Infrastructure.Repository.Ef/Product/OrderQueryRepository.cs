using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.Product
{
    public class OrderQueryRepository: IOrderQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<List<OrderForOrderDetailDto>?> GetOrderByUserIDForAdmin(int buyerId, CancellationToken cancellationToken)
        {
            var order = await _appDbContext.Order.AsNoTracking().Where(x => x.IsDeleted == false && x.IsFinal == true && x.BuyerId==buyerId)
               .Select(o => new OrderForOrderDetailDto()
               {
                   CreatedAt = o.CreatedAt,
                   SiteCommission = o.SiteCommission,
                   StatusId = o.StatusId,
                   StatusName = o.Status.Title,
                   Id = o.Id,
                   TotalAmount = o.TotalAmount,
                   UserName = o.Buyer.UserName,
                   OrderDetails = o.OrderDetails.Select(d => new OrderDetailDto()
                   {
                       Id = d.Id,
                       Count = d.Count,
                       ImageName = d.Product.ImageName,
                       OrderId = o.Id,
                       Price = d.Price,
                       ProductId = d.ProductId,
                       ProductName = d.Product.Name

                   }).ToList()



               }).ToListAsync(cancellationToken);

            return order;


        }

        public async Task<List<OrderForOrderDetailDto>> GetAll(CancellationToken cancellationToken)
        {

            var order = await _appDbContext.Order.AsNoTracking().Where(x => x.IsDeleted == false && x.IsFinal == true)
                .Select(o => new OrderForOrderDetailDto()
                {
                     BuyerId = o.BuyerId,
                      CreatedAt=o.CreatedAt,
                      SiteCommission=o.SiteCommission,
                      StatusId=o.StatusId,
                      StatusName=o.Status.Title,
                     Id=o.Id,
                     TotalAmount=o.TotalAmount,
                     UserName=o.Buyer.UserName,
                     OrderDetails=o.OrderDetails.Select( d=> new OrderDetailDto()
                     {
                           Id=d.Id,
                           Count=d.Count,
                           ImageName=d.Product.ImageName,
                           OrderId=o.Id,
                           Price=d.Price,
                           ProductId=d.ProductId,
                           ProductName=d.Product.Name

                     }).ToList()
                           
                         

                }).ToListAsync(cancellationToken);

            return order;


        } 


        public async Task<OrderForOrderDetailDto> GetByOrderId(int orderId, CancellationToken cancellationToken)
        {
            var order = await _appDbContext.Order.Where(x => x.Id == orderId).SingleOrDefaultAsync(cancellationToken);

            var dto = new OrderForOrderDetailDto()
            {
               BuyerId = order.BuyerId,
               CreatedAt=order.CreatedAt,
               DeletedAt=order.DeletedAt,
               Id=order.Id,
               IsDeleted=order.IsDeleted,
               IsFinal=order.IsFinal,
               SiteCommission=order.SiteCommission,
                StatusId=order.StatusId,
                StatusName=order.Status.Title,
                UserName=order.Buyer.UserName,
                TotalAmount=order.TotalAmount,
                OrderDetails=order.OrderDetails.Select(x=>new OrderDetailDto()
                {
                    Count=x.Count,
                     Id=x.Id,
                     OrderId=order.Id,
                     ProductId=x.ProductId, 
                     ImageName=x.Product.ImageName,
                      ProductName=x.Product.Name,
                      Price=x.Price

                }).ToList()
                
            };

            return dto;
            
        }
       
        public async Task<List<OrderDetailForOrderDto>?> GetOrderByUserID(int currentUserId,CancellationToken cancellationToken)
        {
            List<OrderDetailForOrderDto> orderShows = new List<OrderDetailForOrderDto>();
            var order = await _appDbContext.Order.SingleOrDefaultAsync(o => o.BuyerId == currentUserId && o.IsFinal == false && o.IsDeleted == false, cancellationToken);

            if (order!=null)
            {

                var detail = await _appDbContext.OrderDetail.Where(d => d.OrderId == order.Id).ToListAsync(cancellationToken);
                foreach (var item in detail)
                {
                    var product = _appDbContext.Product.Find(item.ProductId);
                    orderShows.Add(new OrderDetailForOrderDto()
                    {
                        Count=item.Count,
                         Price=item.Price,
                          OrderId=order.Id,
                          SiteCommission=order.SiteCommission,
                          ProductName=item.Product.Name,
                           ImageName=item.Product.ImageName,
                           Id=item.Id,
                       TotalAmount=Convert.ToInt32(item.Count*item.Price+order.SiteCommission),
                    
                    });

                }

                return orderShows;
            }
            return null;
        }

    }
}
