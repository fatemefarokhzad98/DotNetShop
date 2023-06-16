﻿using App.EndPoint.AdminUi.Models;
using App.Infrastructure.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers
{
    public class ProductController : Controller
    {
        Repository repository = new Repository();
        [HttpGet]
        public IActionResult Apdate(int Id)
        {
            var product = repository.GetIdProduct(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Apdate( Product product)
        {
            repository.UpdateProduct(product);
            return RedirectToAction("Read");
        }
        
        public IActionResult Delete(int id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction("Read");
        }
       [HttpPost]
        public IActionResult Insert(Product product)
        {
            repository.InsertProduct(product);
            return RedirectToAction("Read");
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Read()
        {
           var product= repository.GetProduct();
            return View(product);
        }
        public IActionResult Details(int Id)
        {
            var product = repository.DetailsPeoduct(Id);
            return View(product);
        }


    }
}