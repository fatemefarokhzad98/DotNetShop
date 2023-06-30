using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
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
        private readonly ISurenessService _categorySurnessService;
        public CategoryAppService(ICategoryService categoryService , ISurenessService categorySurnessService)
        {
            _categoryService = categoryService;
            _categorySurnessService = categorySurnessService;

        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            
              return await  _categoryService.GetCategories();

        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category == null)
                throw new Exception();
            return category;
        }

        public async Task<CategoryDto> GetCategory(string name)
        {
            var category = await _categoryService.GetCategory(name);
            if (category == null)
                throw new Exception();
            return category;

        }

        public async Task<int> InsertCategory( bool isActive, int displayOrder, string name, int? parentCategoryId)
        {
            await _categorySurnessService.EnsureModelIsNotExist(name);
            return await _categoryService.InsertCategory(isActive, displayOrder, name, parentCategoryId);
        }

        public Task<int> InsertCategory(int displayOrder, string name, int? parentCategorytId)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> RemoveCategory(int id)
        {
            await _categorySurnessService.EnsureModelIsExist(id);
            return await _categoryService.RemoveCategory(id);
        }

        public async Task<int> UpdateCategory( bool isActive, int displayOrder, string name, int? parentCategoryId, int id)
        {
            await _categorySurnessService.EnsureModelIsExist(id);
            return await _categoryService.UpdateCategory(isActive, displayOrder,name,parentCategoryId,id);
        }


    }
}
