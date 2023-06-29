using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ModelSurenessService: IModelSurenessService
    {
        private readonly IModelQueryRepository _modelQueryRepository;
        public ModelSurenessService(IModelQueryRepository modelQueryRepository)
        {
            _modelQueryRepository = modelQueryRepository;
        }

    }
}
