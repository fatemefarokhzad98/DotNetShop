using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ModelService: IModelService
    {
        private readonly IModelCommandRepository _modelCommandRepository;
        private readonly IModelQueryRepository _modelQueryRepository;

        public ModelService(IModelCommandRepository modelCommandRepository,IModelQueryRepository modelQueryRepository)
        {
            _modelCommandRepository = modelCommandRepository;
            _modelQueryRepository = modelQueryRepository;
        }

        public async Task<ModelDto?> GetModel(int id)
        {
            var model=  await _modelQueryRepository.GetModel(id);
            if (model==null)
            {
                throw new Exception();
            }
            return model;
        }

        public async Task<ModelDto?> GetModel(string name)
        {
            var model= await _modelQueryRepository.GetModel(name);
            if (model == null)
            {
                throw new Exception();
            }
            return model;


        }

        public async Task<List<ModelDto>?> GetModels()
        {
            var model= await _modelQueryRepository.GetModels();
            if (model==null)
            {
                throw new Exception();
            }
            return model;
        }

        public async Task<List<ProductBriefDto>?> GetModelsWithProduct(int? id, string? name)
        {
            var product = await _modelQueryRepository.GetModelsWithProduct(id, name);
            if (product==null)
            {
                throw new Exception();
            }
            return product;
            
        }

        public async Task<int> InsertModel(int brandid, int? parentModelId, string name)
        {
            return await _modelCommandRepository.InsertModel(brandid, false, parentModelId, name);
        }

        public async Task<int> InsertModel(int brandid, bool isDeleted, int? parentModelId, string name)
        {
            return await _modelCommandRepository.InsertModel(brandid,isDeleted, parentModelId, name);
        }

        public async Task<ModelDto> RemoveModel(int id)
        {
            return await  _modelCommandRepository.RemoveModel(id);
        }

        public async Task<int> UpdateModel(int brandid, int? parentModelId, string name, int id)
        {
           return await _modelCommandRepository.UpdateModel(brandid,parentModelId,name,id);
        }
    }
}
