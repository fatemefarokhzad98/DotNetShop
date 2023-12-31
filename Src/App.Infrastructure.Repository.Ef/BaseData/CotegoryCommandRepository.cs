﻿using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;

using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> InsertCategory(bool isDeleted, bool isActive, int displayOrder, string name, int? parentCategoryId)
        {
            Category category = new()
            {
                IsDeleted = isDeleted,
                IsActive = isActive,
                Name = name,
                ParentCategoryId = parentCategoryId,
                DisplayOrder = displayOrder,
            
            };
             _appDbContext.Category.Add(category);
            await _appDbContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task<CategoryDto> RemoveCategory(int id)
        {
            var category = await _appDbContext.Category.Where(x => x.Id == id).SingleAsync();
            var categoryDto = await _appDbContext.Category.Where(x => x.Id == id).AsNoTracking().Select(c => new CategoryDto()
            {
                DisplayOrder = c.DisplayOrder,
                Id = c.Id,
                IsActive = c.IsActive,
                IsDeleted = true,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
                 ParentName=c.ParentCategory.Name
                
            }).FirstOrDefaultAsync();

             _appDbContext.Remove(category);
            await _appDbContext.SaveChangesAsync();
            return categoryDto;
        }

        public async Task<int> UpdateCategory(bool isActive, int displayOrder, string name, int? parentCategoryId, int id)
        {
            var category = await _appDbContext.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
            category.Name = name;
            category.ParentCategoryId = parentCategoryId;
            category.DisplayOrder= displayOrder;
            category.IsActive = isActive;
           
            await _appDbContext.SaveChangesAsync();
            return category.Id;

        }
    }
}
