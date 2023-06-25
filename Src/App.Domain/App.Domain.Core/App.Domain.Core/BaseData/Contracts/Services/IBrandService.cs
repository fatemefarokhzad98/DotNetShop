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
        List<BrandDto> GetBrands();
        void SetBrand(int displayOrder, string name);
        BrandDto GetBrand(int id);
        BrandDto GetBrand(string name);
        void UpdateBrand(int id, int displayOrder, string name);
        void RemoveBrand(int id);

    }
}
