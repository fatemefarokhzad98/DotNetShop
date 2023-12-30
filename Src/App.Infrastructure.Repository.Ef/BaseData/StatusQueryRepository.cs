using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class StatusQueryRepository: IStatusQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public StatusQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;


        }
        public async Task<List<StatusDto>> GetStatuses()
        {
            return await _appDbContext.Status.AsNoTracking().Where(x=>x.IsDeleted==false).Select( x => new StatusDto
            {
                Id = x.Id,
                Title = x.Title,
                ForComment = x.ForComment,
                ForProduct = x.ForProduct,
                ForOrder=x.ForOrder,
                IsDeleted=false,
                
                

            }).ToListAsync();
            
            
        }
        public async Task<List<StatusDto>> GetProductStatus()
        {
            var statusProduct = await _appDbContext.Status.Where(x => x.ForProduct == true && x.IsDeleted == false)
                .Select(s => new StatusDto()
                {
                    Title=s.Title,
                    ForComment=s.ForComment,
                     ForOrder=s.ForOrder,
                     ForProduct=s.ForProduct,   
                      Id=s.Id,
                       IsDeleted=false

                }).ToListAsync();
                
            return statusProduct;
        }
        public async Task<List<StatusDto>> GetCommentStatus()
        {
            var statusProduct = await _appDbContext.Status.Where(x => x.ForComment == true && x.IsDeleted == false)
                .Select(s => new StatusDto()
                {
                    Title = s.Title,
                    ForComment = s.ForComment,
                    ForOrder = s.ForOrder,
                    ForProduct = s.ForProduct,
                    Id = s.Id,
                    IsDeleted = false

                }).ToListAsync();

            return statusProduct;
        }
        public async Task<List<StatusDto>> GetOrderStatus()
        {
            var statusProduct = await _appDbContext.Status.Where(x => x.ForOrder == true && x.IsDeleted == false)
                .Select(s => new StatusDto()
                {
                    Title = s.Title,
                    ForComment = s.ForComment,
                    ForOrder = s.ForOrder,
                    ForProduct = s.ForProduct,
                    Id = s.Id,
                    IsDeleted = false

                }).ToListAsync();

            return statusProduct;
        }
        public async Task<StatusDto> GetStatus(int id)
        {
           var result = await _appDbContext.Status.AsNoTracking().Where(x=>x.IsDeleted==false &&x.Id==id).Select(x => new StatusDto
           {
               Id =id,
               Title = x.Title,
               ForOrder=x.ForOrder,
               ForComment = x.ForComment,
               ForProduct = x.ForProduct,
               IsDeleted=false
           }).FirstOrDefaultAsync();

            return result;

        }

        public async Task<StatusDto> GetStatus(string title)
        {
            var result = await _appDbContext.Status.AsNoTracking().Where(x => x.IsDeleted == false && x.Title==title).Select(x => new StatusDto
            {
                Id = x.Id,
                Title = title,
                ForOrder = x.ForOrder,
                ForComment = x.ForComment,
                ForProduct = x.ForProduct,
                IsDeleted = false
            }).FirstOrDefaultAsync();

            return result;

        }
    }
}
