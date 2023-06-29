using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
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
        private readonly IModelSurenessService _modelSurnessService;
        public ModelAppService(IModelService modelService,IModelSurenessService modelSurnessService )
        {
            
            _modelService = modelService;
            _modelSurnessService = modelSurnessService;
        }
    }
}
