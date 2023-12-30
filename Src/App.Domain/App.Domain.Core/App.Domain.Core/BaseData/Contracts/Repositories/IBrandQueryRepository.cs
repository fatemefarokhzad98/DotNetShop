using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandQueryRepository
    {
        Task<BrandDto?> GetBrand(int id);
        Task<List<ProductBriefDto>?> GetBrandsWithProduct(int? id, string? name);
        Task<BrandDto?> GetBrand(string Name);
        Task<List<BrandDto>?> GetBrands();


    }
}
