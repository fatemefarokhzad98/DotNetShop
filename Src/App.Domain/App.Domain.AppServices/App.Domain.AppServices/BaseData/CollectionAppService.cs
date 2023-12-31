﻿using App.Domain.Core.BaseData.Contracts.AppServices;
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
       
        private readonly IColletionSurnessService _collectionSurnessService;
        public CollectionAppService(ICollectionService collectionService, IColletionSurnessService collectionSurnessService)
        {
            _collectionService = collectionService;
            _collectionSurnessService = collectionSurnessService;

        }

     

        public async Task<List<CollectionDto>?> GetCollection()
        {
           return await _collectionService.GetCollection();
        }

        public async Task<CollectionDto?> GetCollection(int id)
        {
            return await _collectionService.GetCollection(id);
        }

        public async Task<CollectionDto?> GetCollection(string name)
        {
            return await _collectionService.GetCollection(name);
        }

     
        public async Task<int> InsertCollection(string name )
        {
           await _collectionSurnessService.EnsureModelIsNotExist(name);
            return await _collectionService.InsertCollection(name);
        }

        public async Task<CollectionDto> RemoveCollection(int id)
        {
            await _collectionSurnessService.EnsureModelIsExist(id);
            return await _collectionService.RemoveCollection(id);
                
                
        }

        public async Task<int> UpdateCollection(string name, int id)
        {
          await  _collectionSurnessService.EnsureModelIsExist(id);
            return await _collectionService.UpdateCollection(name, id);
        }
    }
}
