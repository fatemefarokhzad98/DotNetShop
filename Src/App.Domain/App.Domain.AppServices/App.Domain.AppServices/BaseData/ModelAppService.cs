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
    public class ModelAppService: IModelAppService
    {
        private readonly IModelService _modelService;
        private readonly IModelSurnessService _modelSurnessService;
        public ModelAppService(IModelService modelService, IModelSurnessService modelSurnessService )
        {
            
            _modelService = modelService;
            _modelSurnessService = modelSurnessService;
        }

        public async Task<ModelDto> GetModel(int id)
        {
            var model = await _modelService.GetModel(id);
            if (model == null)
                throw new Exception();
            return model;
        }

        public async Task<ModelDto> GetModel(string name)
        {
            var model = await _modelService.GetModel(name);
            if (model == null)
                throw new Exception();
            return model;
        }

        public async Task<List<ModelDto>> GetModels()
        {
            return await _modelService.GetModels();
        }

        public async Task<int> InsertModel(int brandid, int? parentModelId, string name)
        {
            await _modelSurnessService.EnsureModelIsNotExist(name);
            return await _modelService.InsertModel(brandid,parentModelId, name);
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
