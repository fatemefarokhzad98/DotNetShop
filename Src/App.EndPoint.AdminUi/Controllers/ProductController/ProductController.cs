using App.EndPoint.AdminUi.Models;
using App.Infrastructure.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers.ProductController
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;
        public ProductController(ProductRepository repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var product = _repository.GetIdProduct(Id);
            return View("Update",product);
        }
        [HttpPost]
        public IActionResult Apdate( Product product)
        {
            _repository.UpdateProduct(product);
            return RedirectToAction("Read");
        }
        
        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Read");
        }
       [HttpPost]
        public IActionResult Insert(Product product)
        {
            _repository.InsertProduct(product);
            return RedirectToAction("Read");
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Read()
        {
           var product= _repository.GetProduct();
            return View("Read",product);
        }
        public IActionResult Details(int Id)
        {
            var product = _repository.DetailsProduct(Id);
            return View("Details",product);
        }


    }
}
