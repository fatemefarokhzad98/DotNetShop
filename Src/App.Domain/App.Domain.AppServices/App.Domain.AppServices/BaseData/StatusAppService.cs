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
    public class StatusAppService : IStatusAppService
    {
        private readonly IStatusService _statusService;
        private readonly IStatusSurnessService _statusSurnessService;

        public StatusAppService(IStatusService statusService ,IStatusSurnessService statusSurnessService)
        {
            _statusService = statusService;
            _statusSurnessService = statusSurnessService;


        }

        public async Task CreateStatus(string title, bool forComment, bool forProduct, bool forOrder)
        {
          await  _statusSurnessService.EnsureModelIsNotExist(title);
          await  _statusService.CreateStatus(title,forComment,forProduct, forOrder);  
        }

        public async Task<List<StatusDto>> GetCommentStatus()
        {
           return await _statusService.GetCommentStatus();

        }

        public async Task<List<StatusDto>> GetOrderStatus()
        {
            return await _statusService.GetOrderStatus();
        }

        public async Task<List<StatusDto>> GetProductStatus()
        {
            return await _statusService.GetProductStatus();
        }

        public async Task<StatusDto> GetStatus(int id)
        {
           return await _statusService.GetStatus(id);
        }
        public async Task<StatusDto> GetStatus(string title)
        {
            return await _statusService.GetStatus(title);   
        }

        public async Task<List<StatusDto>> GetStatuses()
        {
            return await _statusService.GetStatuses();
        }

        public async Task RemoveStatus(int id)
        {
           await _statusSurnessService.EnsureModelIsExist(id);
           await _statusService.RemoveStatus(id);
        }

        public async Task UpdateStatus(int id, string title, bool forComment, bool forProduct, bool forOrder)
        {
           await _statusSurnessService.EnsureModelIsExist(id);
            await _statusService.UpdateStatus(id, title, forComment, forProduct, forOrder);
        }
    }
}
