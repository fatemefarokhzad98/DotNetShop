using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class CategoryQueryRepository: ICategoryQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CategoryDto?> GetCategory(int? id)
        {
            var category = await _appDbContext.Categories
                .Where(x => x.Id == id).AsNoTracking()
              
                .Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                DisplayOrder = c.DisplayOrder,
                IsActive = c.IsActive,
                ParentCategoryId = c.ParentCategoryId,
                IsDeleted = c.IsDeleted,
                ParentName=c.ParentCategory.Name
            }).FirstOrDefaultAsync();
            return category;

        }

        public async Task<CategoryDto?> GetCategory(string name)
        {
            var category = await _appDbContext.Categories.Where(x => x.Name == name).AsNoTracking().Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                DisplayOrder = c.DisplayOrder,
                IsActive = c.IsActive,
                ParentCategoryId = c.ParentCategoryId,
                IsDeleted = c.IsDeleted,
                ParentName=c.ParentCategory.Name
            }).SingleOrDefaultAsync();
            return category;

        }

        public async Task<List<CategoryDto>> GetCategories()
        {

            var categories = await _appDbContext.Categories.AsNoTracking().Select(c => new CategoryDto()
            {
                 DisplayOrder=c.DisplayOrder,
                 Id=c.Id,
                 IsActive=c.IsActive,
                 IsDeleted=c.IsDeleted,
                 Name=c.Name,
                 ParentCategoryId=c.ParentCategoryId,
                 ParentName=c.ParentCategory.Name

            }).ToListAsync();
            return categories;
        }
    }
}
