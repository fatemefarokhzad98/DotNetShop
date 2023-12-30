using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class CategoryAppService: ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategorySurnessService _categorySurnessService;
        public CategoryAppService(ICategoryService categoryService , ICategorySurnessService categorySurnessService)
        {
            _categoryService = categoryService;
            _categorySurnessService = categorySurnessService;

        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _categoryService.GetCategories();
            
        }

        public async Task<CategoryDto?> GetCategory(int id)
        {
            return await _categoryService.GetCategory(id);
        }

        public async Task<CategoryDto?> GetCategory(string name)
        {
            return await _categoryService.GetCategory(name);
        }

        public async Task<List<ProductBriefDto?>> GetCategoryWithProduct(int? id, string? name)
        {
            return await _categoryService.GetCategoryWithProduct(id, name);
        }

        public async Task<int> InsertCategory(bool isActive, int displayOrder, string name, int? parentCaregoryId)
        {
           await _categorySurnessService.EnsureModelIsNotExist(name);
            return await _categoryService.InsertCategory( isActive, displayOrder, name, parentCaregoryId);
        }

        public async Task<CategoryDto> RemoveCategory(int id)
        {
           await _categorySurnessService.EnsureModelIsExist(id);
            return await _categoryService.RemoveCategory(id);
        }

        public async Task<int> UpdateCategory(bool isActive, int displayOrder, string name, int? parentCategoryId, int id)
        {
           await _categorySurnessService.EnsureModelIsExist(id);
            return await _categoryService.UpdateCategory(isActive,displayOrder,name,parentCategoryId,id);
        }
    }
}
