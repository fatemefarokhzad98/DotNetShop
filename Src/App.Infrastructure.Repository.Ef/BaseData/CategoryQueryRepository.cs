using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
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

        public async Task<CategoryDto?> GetCategory(int id)
        {
            var category = await _appDbContext.Category
                .Where(x => x.Id == id && x.IsDeleted==false).AsNoTracking()
              
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
            var category = await _appDbContext.Category.Where(x => x.Name == name &&x.IsDeleted==false).AsNoTracking().Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                DisplayOrder = c.DisplayOrder,
                IsActive = c.IsActive,
                ParentCategoryId = c.ParentCategoryId,
                IsDeleted = false,
                ParentName=c.ParentCategory.Name
            }).SingleOrDefaultAsync();
            return category;

        }

        public async Task<List<CategoryDto>> GetCategories()
        {

            var categories = await _appDbContext.Category.AsNoTracking().Where(x=>x.IsDeleted==false).Select(c => new CategoryDto()
            {
                 DisplayOrder=c.DisplayOrder,
                 Id=c.Id,
                 IsActive=c.IsActive,
                 IsDeleted=false,
                 Name=c.Name,
                 ParentCategoryId=c.ParentCategoryId,
                 ParentName=c.ParentCategory.Name

            }).ToListAsync();
            return categories;
        }

        public async Task<List<ProductBriefDto?>> GetCategoryWithProduct(int? id,string? name)
        {
            List<ProductBriefDto> products = new List<ProductBriefDto>();
           
            var product = await _appDbContext.Product.Where(x => x.CategoryId == id && x.IsDeleted == false || x.Category.Name == name && x.IsDeleted == false).ToListAsync();
            if (product!=null)
            {
                foreach (var item in product)
                {
                    products.Add(new ProductBriefDto()
                    {
                        Id = item.Id,
                        BrandName = item.Brand.Name,
                        Name = item.Name,
                        ImageName = item.ImageName,
                        Count = item.Count,
                        IsOrginal = item.IsOrginal,
                        Price = item.Price,
                        IsDeleted = false,
                        CategoryName = item.Category.Name,
                        Colors = item.ProductColors.Select(x => new ColorDto()
                        {
                            Id = x.Id,
                            ColorCode = x.Color.ColorCode,
                            IsDeleted = x.Color.IsDeleted,
                            Name = x.Color.Name
                        }).ToList()
                    });
                }
                return products;

            }
            return null;
         
        }
      
    }
}
