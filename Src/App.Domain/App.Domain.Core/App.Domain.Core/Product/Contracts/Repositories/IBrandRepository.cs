﻿using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrnds();
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void RemoveBrand(int Id);
        Brand? GetId (int Id);
        Brand? GetName(string Name);

    }
}
