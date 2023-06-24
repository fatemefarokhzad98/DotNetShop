using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductService
    {
        List<Brand> GetAllBrnds();
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void RemoveBrand(int Id);
        Brand Exist(int Id);
    }
}
