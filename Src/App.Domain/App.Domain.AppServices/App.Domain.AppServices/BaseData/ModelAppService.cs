using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class ModelAppService: IModelAppService
    {
        private readonly IModelService _modelService;
        private readonly IModelSurnessService _modelSurnessService;
        public ModelAppService(IModelService modelService, IModelSurnessService modelSurnessService )
        {
            
            _modelService = modelService;
            _modelSurnessService = modelSurnessService;
        }

        public async Task<ModelDto?> GetModel(int id)
        {
            return await _modelService.GetModel(id);
        }

        public async Task<ModelDto?> GetModel(string name)
        {
            return await _modelService.GetModel(name);
        }

        public async Task<List<ModelDto>?> GetModels()
        {
            return await _modelService.GetModels();
        }

        public async Task<List<ProductBriefDto>?> GetModelsWithProduct(int? id, string? name)
        {
            return await _modelService.GetModelsWithProduct(id, name);
        }

        public async Task<int> InsertModel(int brandid, int? parentModelId, string name)
        {
           await _modelSurnessService.EnsureModelIsNotExist(name);
            return await _modelService.InsertModel(brandid, parentModelId, name);
        }

        public async Task<ModelDto> RemoveModel(int id)
        {
           await _modelSurnessService.EnsureModelIsExist(id);
           return await _modelService.RemoveModel(id);
        }

        public async Task<int> UpdateModel(int brandid, int? parentModelId, string name, int id)
        {
           await _modelSurnessService.EnsureModelIsExist(id);
            return await _modelService.UpdateModel(brandid, parentModelId, name, id);
        }
    }
}
