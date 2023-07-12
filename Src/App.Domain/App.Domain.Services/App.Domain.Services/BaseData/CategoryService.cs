using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        public CategoryService(ICategoryCommandRepository categoryCommandRepository,ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
         return await  _categoryQueryRepository.GetCategories();
        }

        public async Task<CategoryDto> GetCategory(int? id)
        {
           var category= await _categoryQueryRepository.GetCategory(id);
            
            return category;
        }

        public async Task<CategoryDto> GetCategory(string name)
        {
            var category = await _categoryQueryRepository.GetCategory(name);
            if (category == null)
                throw new Exception();
            return category;
        }

        public async Task<int> InsertCategory(bool isActive, int displayOrder, string name, int? parentCategoryId)
        {
            return await _categoryCommandRepository.InsertCategory(false, isActive, displayOrder, name, parentCategoryId);
        }

        public async Task<CategoryDto> RemoveCategory(int id)
        {
            return await _categoryCommandRepository.RemoveCategory(id);
        }

        public async Task<int> UpdateCategory( bool isActive, int displayOrder, string name, int? parentCategoryId, int id)
        {
            return await _categoryCommandRepository.UpdateCategory(isActive, displayOrder, name, parentCategoryId, id);
        }
    }
}
