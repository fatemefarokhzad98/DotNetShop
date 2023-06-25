using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandQueryRepository
    {
        List<BrandDto> GetAllBrnds();
        
        BrandDto? GetBrand (int Id);
        BrandDto? GetBrand(string Name);

    }
}
