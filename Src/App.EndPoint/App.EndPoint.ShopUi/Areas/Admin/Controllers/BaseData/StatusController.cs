using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Areas.Admin.Controllers.BaseData
{
    [Area("Admin")]
    public class StatusController : Controller
    {
        private readonly IStatusAppService _statusAppService;

        public StatusController(IStatusAppService statusAppService )
        {
            _statusAppService = statusAppService;

        }
        [HttpGet]
        public   IActionResult CreateStatus()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult > CreateStatus(StatusCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _statusAppService.CreateStatus(model.Title, model.ForComment, model.ForProduct, model.ForOrder);
                return RedirectToAction("ReadStatus");

            }
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> UpdateStatus(StatusReadViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _statusAppService.UpdateStatus(model.Id,model.Title,model.ForComment,model.ForProduct,model.ForOrder);
                return RedirectToAction("ReadStatus");

            }
            return View(model);

        }
        [HttpGet]
        public async Task <IActionResult> UpdateStatus(int id)
        {
            var model = await _statusAppService.GetStatus(id);
            StatusReadViewModel result = new()
            {
                Id = id,
                Title=model.Title,
                ForComment=model.ForComment,
                ForProduct=model.ForProduct,
                ForOrder=model.ForOrder
                 


            };
            return View(result);

        }
        [HttpGet]
        public async Task< IActionResult> ReadStatus()
        {
            var model = await _statusAppService.GetStatuses();
            var result = model.Select(x => new StatusReadViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                ForComment = x.ForComment,
                ForProduct = x.ForProduct,
               ForOrder=x.ForOrder
            }).ToList();

            return View (result);


        }
        public async Task< IActionResult> RemoveStatus(int id)
        {
            await _statusAppService.RemoveStatus(id);
            return RedirectToAction("ReadStatus");
        }
    }
}
