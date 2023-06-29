using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IModelQueryRepository
    {
        Task<ModelDto?> GetModel(string name);
        Task<ModelDto?> GetModel(int id);
        Task<List<ModelDto>> ReadMole();

    }
}
