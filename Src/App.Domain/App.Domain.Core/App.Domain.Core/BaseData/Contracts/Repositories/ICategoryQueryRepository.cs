﻿using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface ICategoryQueryRepository
    {
        Task<List<CategoryDto>> GetCategories();

        Task<CategoryDto?> GetCategory(int id);
        Task<CategoryDto?> GetCategory(string name);
        Task<List<ProductBriefDto?>> GetCategoryWithProduct(int? id, string? name);

    }
}
