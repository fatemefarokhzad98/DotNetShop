using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IBrandService
    {
        Task CreateBrand(string name, int displayOrder);
        Task UpdateBrand(string name, int displayOrder, int id);
        Task RemoveBrand(int id);
        Task<BrandDto?> GetBrand(int id);
        Task<List<ProductBriefDto>?> GetBrandsWithProduct(int? id, string? name);
        Task<BrandDto?> GetBrand(string Name);
        Task<List<BrandDto>?> GetBrands();


    }
}
