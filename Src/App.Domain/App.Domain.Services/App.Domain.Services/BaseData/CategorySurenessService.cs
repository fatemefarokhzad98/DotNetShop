using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CategorySurenessService:ICategorySurnessService
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        public CategorySurenessService(ICategoryQueryRepository categoryQueryRepository,ICategoryCommandRepository categoryCommandRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task EnsureModelIsExist(int id)
        {
            var category = await _categoryQueryRepository.GetCategory(id);
            if (category == null)
                throw new Exception();
        }

        public async Task EnsureModelIsExist(string name)
        {
            var category = await _categoryQueryRepository.GetCategory(name);
            if (category == null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(int id)
        {
            var category = await _categoryQueryRepository.GetCategory(id);
            if (category != null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(string name)
        {
            var category = await _categoryQueryRepository.GetCategory(name);
            if (category != null)
                throw new Exception();
        }
       




    }
}
