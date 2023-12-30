using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class StatusSurnessService : IStatusSurnessService
    {
        private readonly IStatusCommandRepository _statusCommandRepository;

        private readonly IStatusQueryRepository _statusQueryRepository;

        public StatusSurnessService(IStatusCommandRepository statusCommandRepository, IStatusQueryRepository statusQueryRepository)
        {
            _statusCommandRepository = statusCommandRepository;

            _statusQueryRepository = statusQueryRepository;
        }
        public async Task EnsureModelIsExist(int id)
        {
           var status= await _statusQueryRepository.GetStatus(id);
            if (status == null)
                throw new Exception();

            
        }

        public async Task EnsureModelIsNotExist(string title)
        {
            var status = await _statusQueryRepository.GetStatus(title);
            if (status != null)
                throw new Exception();
        }
    }
}
