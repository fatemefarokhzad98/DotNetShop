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

        public async Task<CollectionDto> GetCollection(int id)
        {
            return await _collectionQueryRepository.GetCollection(id);
        }

        public async Task<CollectionDto> GetCollection(string name)
        {
            return await _collectionQueryRepository.GetCollection(name);
        }

        public async Task<List<CollectionDto>> GetCollectionDtos()
        {
            return await _collectionQueryRepository.ReadCollection();
        }

        public async Task<int> InsertCollection(string name, bool isDeleted)
        {
            return await _collectionCommandRepository.InsertCollection(name, isDeleted);
        }

        public async Task<CollectionDto> RemoveCollection(int id)
        {
            return await _collectionCommandRepository.RemoveCollection(id);

        }

        public async Task<int> UpdateCollection(string name, bool isDeleted, int id)
        {
            return await _collectionCommandRepository.UpdateCollection(name, false, id);

        }
    }
}
