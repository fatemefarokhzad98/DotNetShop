using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.AdminUserUi.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;


namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async Task< IActionResult> ReadCategory()
        {
            var categories = await _categoryAppService.GetCategories();
            var categoryviewmodel = categories.Select(c => new CategoryInPurViewModel()
            {
                Name = c.Name,
             
                IsActive = c.IsActive,
                ParentCategoryId = c.ParentCategoryId

            }).ToList();
 
            return  View(categoryviewmodel);
        }
        [HttpPost]
        public async Task< IActionResult> UpdateCategory(CategoryOutPutViewModel category)
        {
             await _categoryAppService.UpdateCategory( category.IsActive, category.DisplayOrder,category.Name,category.ParentCategoryId, category.Id);
          return  RedirectToAction("ReadCategory");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category=await _categoryAppService.GetCategory(id);
            CategoryOutPutViewModel categoriViewModel = new()
            {
                Id = id,
                ParentCategoryId = category.ParentCategoryId,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted
            };
            return View(categoriViewModel);

        }
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var category = await _categoryAppService.RemoveCategory(id);
            return RedirectToAction("ReadCategory");
        }
        [HttpGet]
        public  IActionResult InsertCategory()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryOutPutViewModel category)
        {
            await _categoryAppService.InsertCategory( category.DisplayOrder, category.Name, category.ParentCategoryId);
            return RedirectToAction("ReadCategory");
        }


             


    }
}
