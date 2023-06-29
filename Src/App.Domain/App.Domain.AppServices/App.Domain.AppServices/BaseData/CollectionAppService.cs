using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class CollectionAppService: ICollectionAppService
    {
        private readonly ICollectionService _collectionService;
       
        private readonly ISurenessService _collectionSurnessService;
        public CollectionAppService(ICollectionService collectionService, ISurenessService collectionSurnessService)
        {
            _collectionService = collectionService;
            _collectionSurnessService = collectionSurnessService;

        }

        public async Task<CollectionDto> GetCollection(int id)
        {
            return await 
        }

        public Task<CollectionDto> GetCollection(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<CollectionDto>> GetCollectionDtos()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertCollection(string name, bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionDto> RemoveCollection(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCollection(string name, bool isDeleted, int id)
        {
            throw new NotImplementedException();
        }
    }
}
