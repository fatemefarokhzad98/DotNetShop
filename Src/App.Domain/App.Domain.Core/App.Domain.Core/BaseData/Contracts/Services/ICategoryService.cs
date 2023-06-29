﻿using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task<CategoryDto> GetCategory(string name);
        Task<int> UpdateCategory(bool isDeleted, bool isActive, int displayOrder, string name, int categoryParentId,int id);
        Task<CategoryDto> RemoveCategory(int id);

        Task<int> InsertCategory(bool isDeleted, bool isActive, int displayOrder, string name, int categoryParentId);
    }
}
