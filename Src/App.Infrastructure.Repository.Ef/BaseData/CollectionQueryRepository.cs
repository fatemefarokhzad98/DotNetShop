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
    public class CollectionQueryRepository: ICollectionQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CollectionQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CollectionDto?> GetCollection(int id)
        {
            var collection = await _appDbContext.Collection.Where(x => x.Id == id).AsNoTracking().Select(c => new CollectionDto()
            {
                Id= c.Id,   
                IsDeleted=c.IsDeleted,
                Name=c.Name

            }).FirstOrDefaultAsync();
            return collection;
            
        }

        public async Task<CollectionDto?> GetCollection(string name)
        {
            var collection = await _appDbContext.Collection.Where(x => x.Name== name).AsNoTracking().Select(c => new CollectionDto()
            {
                Id = c.Id,
                IsDeleted = c.IsDeleted,
                Name = c.Name

            }).FirstOrDefaultAsync();
            return collection;
        }

        public async Task<List<CollectionDto>> ReadCollection()
        {
            var collections = await _appDbContext.Collection.AsNoTracking().Select(c => new CollectionDto()
            {
                Name = c.Name,
                Id = c.Id,
                IsDeleted=c.IsDeleted

            }).ToListAsync();
            return collections;
         
            
        }
    }
}
