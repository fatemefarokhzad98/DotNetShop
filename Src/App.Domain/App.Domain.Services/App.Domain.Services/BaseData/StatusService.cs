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
    public class StatusService : IStatusService
    {
        private readonly IStatusCommandRepository _statusCommandRepository;

        private readonly IStatusQueryRepository _statusQueryRepository;

        public StatusService(IStatusCommandRepository statusCommandRepository,IStatusQueryRepository statusQueryRepository )
        {
            _statusCommandRepository = statusCommandRepository;

            _statusQueryRepository = statusQueryRepository;
        }
      
        public async Task CreateStatus(string title, bool forComment, bool forProduct,bool forOrder)
        {
            await _statusCommandRepository.CreateStatus(title,forComment,forProduct,false, forOrder);
            
        }

        public async Task<List<StatusDto>> GetCommentStatus()
        {
            var status = await _statusQueryRepository.GetCommentStatus();
            if (status==null)
            {
                throw new Exception();
            }
            return status;
        }

        public async Task<List<StatusDto>> GetOrderStatus()
        {
            var status = await _statusQueryRepository.GetOrderStatus();
            if (status == null)
            {
                throw new Exception();
            }
            return status;
        }

        public async Task<List<StatusDto>> GetProductStatus()
        {
            var status = await _statusQueryRepository.GetProductStatus();
            
            return status;
        }

        public async Task<StatusDto> GetStatus(int id)
        {
             var status= await _statusQueryRepository.GetStatus(id);
           
            return status;
        }
        public async Task<StatusDto> GetStatus(string title)
        {
            var status = await _statusQueryRepository.GetStatus(title);
           
            return status;
        }
        public async Task<List<StatusDto>> GetStatuses()
        {
            var status= await _statusQueryRepository.GetStatuses();
           
            return status;
        }

        public async Task RemoveStatus(int id)
        {
           await _statusCommandRepository.RemoveStatus(id);
        }

        public async Task UpdateStatus(int id, string title, bool forComment, bool forProduct, bool forOrder)
        {
            await _statusCommandRepository.UpdateStatus(id, title, forComment, forProduct, forOrder);
        }
    }
}
