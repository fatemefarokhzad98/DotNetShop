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

        public Task<List<CategoryDto>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertCategory(bool isDeleted, bool isActive, int displayOrder, string name, int categoryParentId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> RemoveCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCategory(bool isDeleted, bool isActive, int displayOrder, string name, int categoryParentId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
