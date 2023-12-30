using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IStatusQueryRepository
    {
        public  Task<List<StatusDto>> GetStatuses();
        public  Task<StatusDto> GetStatus(int id);
        public  Task<StatusDto> GetStatus(string title);
        public Task<List<StatusDto>> GetOrderStatus();
        public Task<List<StatusDto>> GetCommentStatus();
        public Task<List<StatusDto>> GetProductStatus();



    }
}
