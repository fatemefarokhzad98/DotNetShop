﻿using App.EndPoint.AdminUi.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers
{
    public class CommentController : Controller
    {
        Repository repository = new Repository();
        public IActionResult Read()
        {
            var model = repository.ReadComment();


            return View(model);
        }
        public IActionResult  Rejectete(int Id)
        {
            repository.RejectComment(Id);
            return RedirectToAction("Read");
        }
        public IActionResult Confirm(int  Id)
        {
            repository.ConfirmComment(Id);
            return RedirectToAction("Read");
        }


    }
}
