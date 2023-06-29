using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CollectionSurenessService:ICollectionSurenessService
    {
        private readonly ICollectionQueryRepository _collectionQueryRepository;
        public CollectionSurenessService(ICollectionQueryRepository collectionQueryRepository)
        {
            _collectionQueryRepository =collectionQueryRepository;
        }
    }
}
