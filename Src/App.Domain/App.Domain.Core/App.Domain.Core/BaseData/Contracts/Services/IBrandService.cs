using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IBrandService
    {
       Task< List<BrandDto>> GetBrands();
       Task SetBrand(int displayOrder, string name);
       Task< BrandDto> GetBrand(int id);
       Task< BrandDto> GetBrand(string name);
       Task UpdateBrand(int id, int displayOrder, string name);
       Task RemoveBrand(int id);

    }
}
