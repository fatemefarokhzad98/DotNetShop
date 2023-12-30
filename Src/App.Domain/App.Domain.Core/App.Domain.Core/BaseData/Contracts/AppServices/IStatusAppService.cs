using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IStatusAppService
    {
        public Task<List<StatusDto>> GetStatuses();
        public Task<StatusDto> GetStatus(int id);
        public Task<StatusDto> GetStatus(string title);
        public Task CreateStatus(string title, bool forComment, bool forProduct, bool forOrder);
        public Task RemoveStatus(int id);
        public Task UpdateStatus(int id, string title, bool forComment, bool forProduct, bool forOrder);
        public Task<List<StatusDto>> GetOrderStatus();
        public Task<List<StatusDto>> GetCommentStatus();
        public Task<List<StatusDto>> GetProductStatus();
    }
}
