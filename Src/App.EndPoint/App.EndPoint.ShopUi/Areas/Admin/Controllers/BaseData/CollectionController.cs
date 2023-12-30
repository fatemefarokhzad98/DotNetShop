using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.ShopUi.Area.Admin.Controllers.BaseData
{
    [Area("Admin")]
    public class CollectionController : Controller
    {
        private readonly ICollectionAppService _collectionApp;
        public CollectionController(ICollectionAppService collectionApp)
        {
            _collectionApp = collectionApp;
        }
        public async Task< IActionResult> ReadCollection()
        {
            var collection = await  _collectionApp.GetCollection();
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
            await _collectionApp.RemoveCollection(id);
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
                await _collectionApp.InsertCollection(collection.Name);
                return RedirectToAction("ReadCollection");
            }
            return View(collection);

        }
        [HttpPost]
        public async Task< IActionResult> UpdateCollection(CollectionUpdateViewModel collection )
        {
            if (ModelState.IsValid)
            {


                await _collectionApp.UpdateCollection(collection.Name, collection.Id);
                return RedirectToAction("ReadCollection");
            }
            return View(collection);
        }
        public async Task<IActionResult> UpdateCollection(int id)
        {
            var collection = await _collectionApp.GetCollection(id);
            CollectionUpdateViewModel collectionViewModel = new()
            {
                Id = id,
                Name = collection.Name
            };
            return View(collectionViewModel);
        }


    }
}
