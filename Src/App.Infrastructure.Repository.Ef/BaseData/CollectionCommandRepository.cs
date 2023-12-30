using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class CollectionCommandRepository: ICollectionCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CollectionCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> InsertCollection(string name, bool isDeleted,DateTime CreationDate)
        {
            Collection collection = new()
            {
                Name = name,
                IsDeleted = isDeleted,
                CreationDate= CreationDate,
          
            
            };
             _appDbContext.Collection.Add(collection);
            await _appDbContext.SaveChangesAsync();
            return collection.Id;

        }

        public async Task<CollectionDto> RemoveCollection(int id)
        {
            var collection = await _appDbContext.Collection.Where(x => x.Id == id).SingleAsync();
            var collectionto = await _appDbContext.Collection.Where(x => x.Id == id).AsNoTracking().Select(c => new CollectionDto()
            {
                Id = c.Id,
                IsDeleted = true,
                Name = c.Name,
                 DeleteDate =DateTime.Now,

            }).FirstOrDefaultAsync();
           _appDbContext.Remove(collection);
            await _appDbContext.SaveChangesAsync();

            return collectionto;

        }

        public async Task<int> UpdateCollection(string name,int id)
        {
            var collection = await _appDbContext.Collection.Where(x => x.Id == id).SingleAsync();
          
            collection.Name = name;
           
            return collection.Id;
        }

      
    }
}
