using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IModelQueryRepository
    {
        Task<List<ProductBriefDto>?> GetModelsWithProduct(int? id, string? name);
        Task<List<ModelDto>?> GetModels();
        Task<ModelDto?> GetModel(int id);
        Task<ModelDto?> GetModel(string name);

    }
}
