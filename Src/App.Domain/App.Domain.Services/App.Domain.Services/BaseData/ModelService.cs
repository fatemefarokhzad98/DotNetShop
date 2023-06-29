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
    public class ModelService: IModelService
    {
        private readonly IModelCommandRepository _modelCommandRepository;
        private readonly IModelQueryRepository _modelQueryRepository;

        public ModelService(IModelCommandRepository modelCommandRepository,IModelQueryRepository modelQueryRepository)
        {
            _modelCommandRepository = modelCommandRepository;
            _modelQueryRepository = modelQueryRepository;
        }

        public async Task<ModelDto> GetModel(int id)
        {
            return await _modelQueryRepository.GetModel(id);
        }

        public async Task<ModelDto> GetModel(string name)
        {
            return await _modelQueryRepository.GetModel(name);
        }

        public async Task<List<ModelDto>> GetModels()
        {
            return await _modelQueryRepository.ReadModle();
        }

        public async Task<int> InsertModel(int brandid, bool isDeleted, int parentModelId, string name)
        {
            return await _modelCommandRepository.InsertModel(brandid, false, parentModelId, name);
        }

        public async Task<ModelDto> RemoveModel(int id)
        {
            return await  _modelCommandRepository.RemoveModel(id);
        }

        public async Task<int> UpdateModel(int brandid, bool isDeleted, int parentModelId, string name, int id)
        {
           return await _modelCommandRepository.UpdateModel(brandid,isDeleted,parentModelId,name,id);
        }
    }
}
