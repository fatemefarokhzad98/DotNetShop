using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CollectionService:ICollectionService
    {
        private readonly ICollectionCommandRepository _collectionCommandRepository;
        private readonly ICollectionQueryRepository _collectionQueryRepository;

        public CollectionService(ICollectionCommandRepository collectionCommandRepository,ICollectionQueryRepository collectionQueryRepository)
        {
            _collectionCommandRepository = collectionCommandRepository;
            _collectionQueryRepository = collectionQueryRepository;

        }

        public async Task<List<CollectionDto>?> GetCollection()
        {
            var collection= await _collectionQueryRepository.GetCollection();
            if (collection==null)
            {
                throw new Exception();
            }
            return collection;
        }

        public async Task<CollectionDto?> GetCollection(int id)
        {
            var model = await _collectionQueryRepository.GetCollection(id);
            if (model==null)
            {
                throw new Exception();
            }
            return model;
        }

        public async Task<CollectionDto?> GetCollection(string name)
        {
            var model = await _collectionQueryRepository.GetCollection(name);
            if (model==null)
            {
                throw new Exception();
            }
            return model;  
        }

      
        public async Task<int> InsertCollection(string name)
        {
            return await _collectionCommandRepository.InsertCollection(name,false,DateTime.Now);
             

        }

        public async Task<CollectionDto> RemoveCollection(int id)
        {
            return await _collectionCommandRepository.RemoveCollection(id);

        }


        public async Task<int> UpdateCollection(string name, int id)
        {
            return await _collectionCommandRepository.UpdateCollection(name, id);
        }
    }
}
