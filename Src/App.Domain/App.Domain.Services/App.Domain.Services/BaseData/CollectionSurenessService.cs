using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CollectionSurenessService:IColletionSurnessService
    {
        private readonly ICollectionQueryRepository _collectionQueryRepository;
        private readonly ICollectionCommandRepository _collectionCommandRepository;
        public CollectionSurenessService(ICollectionQueryRepository collectionQueryRepository,ICollectionCommandRepository collectionCommandRepository)
        {
            _collectionQueryRepository =collectionQueryRepository;
            _collectionCommandRepository = collectionCommandRepository;

        }

        public async Task EnsureModelIsExist(int id)
        {
            var collection = await _collectionQueryRepository.GetCollection(id);
            if (collection == null)
                throw new Exception();
        }

        public async Task EnSureModelIsExist(string name)
        {
            var collection = await _collectionQueryRepository.GetCollection(name);
            if (collection == null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(int id)
        {
            var collection = await _collectionQueryRepository.GetCollection(id);
            if (collection != null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(string name)
        {
            var collection = await _collectionQueryRepository.GetCollection(name);
            if (collection != null)
                throw new Exception();
        }
    }
}
