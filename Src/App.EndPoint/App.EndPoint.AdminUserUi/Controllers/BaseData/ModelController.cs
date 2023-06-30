using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.AdminUserUi.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class ModelController : Controller
    {
        private readonly IModelAppService _modelAppService;
        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }
        public IActionResult InsertModel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertModel(ModelOutPutViewModel model )
        {

            await _modelAppService.InsertModel(model.BrandId, model.ParentModelId, model.Name);
            return RedirectToAction("ReadModel");


        }

            [HttpGet]
        public async Task<IActionResult> UpdateModel(int id)
        {
            var model = await _modelAppService.GetModel(id);
            ModelOutPutViewModel modelviewmodel = new()
            {
                Id=id,
                Name=model.Name,
                BrandId=model.BrandId,
                ParentModelId=model.ParentModelId,
                IsDeleted = model.IsDeleted
                

            };
            return View(modelviewmodel);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateModel(ModelOutPutViewModel model)
        {
            await _modelAppService.UpdateModel(model.BrandId, model.ParentModelId, model.Name, model.Id);
            return RedirectToAction("ReadModel");
        }

        public async Task<IActionResult> RemoveModel(int id)
        {
            await _modelAppService.RemoveModel(id);
            return RedirectToAction("ReadModel");
        }
        public async Task<IActionResult> ReadModel()
        {
            var model=  await _modelAppService.GetModels();
            var modelviewmodel = model.Select(m => new ModelInPutViewModel()
            {
                Name=m.Name,
                BrandId=m.BrandId,
                ParentModelId=m.ParentModelId
            }).ToList();
            return View(modelviewmodel);
       

        }
    }
}
