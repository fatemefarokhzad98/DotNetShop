using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.ShopUi.Area.Admin.Controllers.BaseData
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private readonly IModelAppService _modelAppService;
        private readonly IBrandAppService _brandAppService;
        public ModelController(IModelAppService modelAppService,IBrandAppService brandAppService)
        {
            _modelAppService = modelAppService;
            _brandAppService = brandAppService;

        }
        public async Task< IActionResult> InsertModel()
        {

            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
          

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertModel(ModelInsertViewModel model )
        {

            if (ModelState.IsValid)
            {
                await _modelAppService.InsertModel(model.BrandId, model.ParentModelId, model.Name);
                return RedirectToAction("ReadModel");
            }
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            return View(model);

        }

            [HttpGet]
        public async Task<IActionResult> UpdateModel(int id)
        {
            var model = await _modelAppService.GetModel(id);
            ModelUpdateViewModel modelviewmodel = new()
            {
                Id=id,
                Name=model.Name,
                BrandId=model.BrandId,
                ParentModelId=model.ParentModelId,
               

            };
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            return View(modelviewmodel);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateModel(ModelUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {


                await _modelAppService.UpdateModel(model.BrandId, model.ParentModelId, model.Name, model.Id);
                return RedirectToAction("ReadModel");
            }
            ViewBag.Models = new SelectList(await _modelAppService.GetModels(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _brandAppService.GetBrands(), "Id", "Name");
            return View(model);
        }

        public async Task<IActionResult> RemoveModel(int id)
        {
            await _modelAppService.RemoveModel(id);
            return RedirectToAction("ReadModel");
        }
        public async Task<IActionResult> ReadModel()
        {
            var model=  await _modelAppService.GetModels();
            var modelviewmodel = model.Select(m => new ModelReadViewModel()
            {
                Name=m.Name,
                BrandId=m.BrandId,
                ParentModelId=m.ParentModelId,
                BrandName=m.BrandName,
                Id=m.Id,
                ParentName=m.ParentName,
    
            }).ToList();
            return View(modelviewmodel);
       

        }
    }
}
