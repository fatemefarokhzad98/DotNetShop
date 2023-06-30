using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IModelCommandRepository
    {
        Task<ModelDto> RemoveModel(int id);
        Task<int> InsertModel(int brandid, bool isDeleted, int ?parentModelId,string name);
        Task<int> UpdateModel(int brandid,  int? parentModelId,string name,int id);

    }
}
