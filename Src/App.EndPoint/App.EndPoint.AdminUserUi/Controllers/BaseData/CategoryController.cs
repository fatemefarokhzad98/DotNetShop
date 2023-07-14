using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.AdminUserUi.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            

            var categoryviewmodel = categories.Select(  c => new CategoryReadViewModel()
            {
              Name=c.Name,
              IsActive=c.IsActive,
              DisplayOrder=c.DisplayOrder,
             ParentName=c.ParentName,
             Id=c.Id

            }).ToList();
            
            return  View(categoryviewmodel);
        }
        [HttpPost]
        public async Task< IActionResult> UpdateCategory(CategoryUpdateViewModel category)
        {
            if (ModelState.IsValid)
            {

                await _categoryAppService.UpdateCategory(category.IsActive, category.DisplayOrder, category.Name, category.ParentCategoryId, category.Id);
                return RedirectToAction("ReadCategory");
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category=await _categoryAppService.GetCategory(id);
            CategoryUpdateViewModel categoryViewModel = new()
            {
                Id = id,
                ParentCategoryId=category.ParentCategoryId,
                ParentName=category.ParentName,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                IsActive = category.IsActive,
               
            };
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");

            return View(categoryViewModel);

        }
        public async Task<IActionResult> RemoveCategory(int id)
         {
             await _categoryAppService.RemoveCategory(id);
            return RedirectToAction("ReadCategory");
        }
        [HttpGet]
       
        public  async Task< IActionResult> InsertCategory()
        {
           
            ViewBag.Categories = new SelectList(await _categoryAppService.GetCategories(), "Id", "Name");
            
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryInsertViewModel category)
        {
            if (ModelState.IsValid)
            {


                await _categoryAppService.InsertCategory(category.IsActive, category.DisplayOrder, category.Name, category.ParentCategoryId);
                return RedirectToAction("ReadCategory");
            }
            return View(category);
        }


             


    }
}
