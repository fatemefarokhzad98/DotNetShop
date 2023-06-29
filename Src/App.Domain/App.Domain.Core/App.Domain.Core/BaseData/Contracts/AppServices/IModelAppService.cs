using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IModelAppService
    {

        Task<ModelDto> RemoveModel(int id);
        Task<int> InsertModel(int brandid, bool isDeleted, int parentModelId, string name);
        Task<int> UpdateModel(int brandid, bool isDeleted, int parentModelId, string name);
        Task<List<ModelDto>> GetModels();
        Task<ModelDto> GetModel(int id);
        Task<ModelDto> GetModel(string name);

 
    }
}
