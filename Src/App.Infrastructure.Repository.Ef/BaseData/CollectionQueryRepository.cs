using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class CollectionQueryRepository: ICollectionQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CollectionQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CollectionDto?> GetCollection(int id)
        {
            var collection = await _appDbContext.Collection.Where(x => x.Id == id&& x.IsDeleted==false).AsNoTracking().Select(c => new CollectionDto()
            {
                Id= c.Id,   
                IsDeleted=false,
                Name=c.Name,
                CreationDate=c.CreationDate,
                DeleteDate=c.DeleteDate

            }).FirstOrDefaultAsync();
            return collection;
            
        }

        public async Task<CollectionDto?> GetCollection(string name)
        {
            var collection = await _appDbContext.Collection.Where(x => x.Name== name&& x.IsDeleted==false).AsNoTracking().Select(c => new CollectionDto()
            {
                Id = c.Id,
                IsDeleted = false,
                Name = c.Name,
                CreationDate=c.CreationDate,
                DeleteDate=c.DeleteDate

            }).FirstOrDefaultAsync();
            return collection;
        }

        public async Task<List<CollectionDto>?> GetCollection()
        {
            var collections = await _appDbContext.Collection.AsNoTracking().Where(x=>x.IsDeleted==false).Select(c => new CollectionDto()
            {
                Name = c.Name,
                Id = c.Id,
                IsDeleted=false,
                DeleteDate=c.DeleteDate,
                CreationDate=c.CreationDate

            }).ToListAsync();
            return collections;
         
            
        }
        
      
    }
}
