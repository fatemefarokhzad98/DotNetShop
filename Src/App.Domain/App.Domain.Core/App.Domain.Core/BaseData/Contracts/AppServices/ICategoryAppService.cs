﻿using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>> GetCategories();
        Task <CategoryDto> GetCategory(int id);
        Task <CategoryDto> GetCategory(string name);
        Task<int> UpdateCategory( bool isActive, int displayOrder, string name, int? parentCategorytId, int id);
        Task<CategoryDto> RemoveCategory(int id);

        Task<int> InsertCategory(int displayOrder, string name, int? parentCategorytId);
    }
}