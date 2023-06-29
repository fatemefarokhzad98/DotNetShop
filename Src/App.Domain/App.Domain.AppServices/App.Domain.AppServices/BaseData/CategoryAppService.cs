using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
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
        private readonly ICategorySurenessService _categorySurnessService;
        public CategoryAppService(ICategoryService categoryService , ICategorySurenessService categorySurnessService)
        {
            _categoryService = categoryService;
            _categorySurnessService = categorySurnessService;

        }

    }
}
