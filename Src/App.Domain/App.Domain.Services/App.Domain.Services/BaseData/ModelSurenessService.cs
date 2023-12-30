using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ModelSurenessService:IModelSurnessService
    {
        private readonly IModelQueryRepository _modelQueryRepository;
        private readonly IModelCommandRepository _modelCommandRepository;
        public ModelSurenessService(IModelQueryRepository modelQueryRepository,IModelCommandRepository modelCommandRepository)
        {
            _modelQueryRepository = modelQueryRepository;
            _modelCommandRepository = modelCommandRepository;
        }

        public async Task EnsureModelIsExist(int id)
        {
           var model=await _modelQueryRepository.GetModel(id);
            if (model == null)
                throw new Exception();

        }

        public async Task EnsureModelIsExist(string name)
        {
            var model = await _modelQueryRepository.GetModel(name);
            if (model == null)
                throw new Exception();
        }

        public  async Task EnsureModelIsNotExist(int id)
        {
            var model = await _modelQueryRepository.GetModel(id);
            if (model != null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(string name)
        {
            var model = await _modelQueryRepository.GetModel(name);
            if (model != null)
                throw new Exception();
        }
    }
}
