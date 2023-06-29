using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
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
    }
}
