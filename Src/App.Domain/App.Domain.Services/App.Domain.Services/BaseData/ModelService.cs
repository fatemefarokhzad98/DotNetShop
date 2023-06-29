using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
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
    }
}
