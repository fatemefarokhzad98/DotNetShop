using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
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
       
        private readonly ICollectionSurenessService _collectionSurnessService;
        public CollectionAppService(ICollectionService collectionService,ICollectionSurenessService collectionSurnessService)
        {
            _collectionService = collectionService;
            _collectionSurnessService = collectionSurnessService;

        }
    }
}
