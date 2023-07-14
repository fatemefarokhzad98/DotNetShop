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
            var collectionviewmodel = collection.Select(c => new CollectionReadViewModel()
            {
                
                Name=c.Name,
                CreationDate=c.CreationDate,
                Id=c.Id
               

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
        public async Task<IActionResult> InsertCollection(CollectionInsertViewModel collection)
        {
            if (ModelState.IsValid)
            {


                await _coolectionAppService.InsertCollection(collection.Name);
                return RedirectToAction("ReadCollection");
            }
            return View(collection);

        }
        [HttpPost]
        public async Task< IActionResult> UpdateCollection(CollectionUpdateViewModel collection )
        {
            if (ModelState.IsValid)
            {


                await _coolectionAppService.UpdateCollection(collection.Name, collection.Id);
                return RedirectToAction("ReadCollection");
            }
            return View(collection);
        }
        public async Task<IActionResult> UpdateCollection(int id)
        {
            var collection = await _coolectionAppService.GetCollection(id);
            CollectionUpdateViewModel collectionViewModel = new()
            {
                Id = id,
                Name = collection.Name
            };
            return View(collectionViewModel);
        }


    }
}
