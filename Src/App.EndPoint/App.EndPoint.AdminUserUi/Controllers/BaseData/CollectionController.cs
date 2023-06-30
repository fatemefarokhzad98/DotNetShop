using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.AdminUserUi.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class CollectionController : Controller
    {
        private readonly ICollectionAppService _coolectionAppService;
        public CollectionController(ICollectionAppService coolectionAppService)
        {
            _coolectionAppService = coolectionAppService;
        }
        public async Task< IActionResult> ReadCollection()
        {
          var collection=  await _coolectionAppService.GetCollectionDtos();
            var collectionviewmodel = collection.Select(c => new CollectionInPutViewModel()
            {
                
                Name=c.Name,
                CreationDate=c.CreationDate
               

            }).ToList();
                return View(collectionviewmodel);
        }
        public async Task<IActionResult> RemoveCollection(int id)
        {
            await _coolectionAppService.RemoveCollection(id);
            return RedirectToAction("ReadCollection");
        }
        [HttpGet]
        public IActionResult InsertCollection()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertCollection(CollectionOutPutViewModel collection)
        {
            await _coolectionAppService.InsertCollection(collection.Name,collection.CreationDate );
            return RedirectToAction("ReadCollection");

        }
    }
}
