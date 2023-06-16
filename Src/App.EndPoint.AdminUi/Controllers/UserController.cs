using App.EndPoint.AdminUi.Models;
using App.Infrastructure.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUi.Controllers
{
    public class UserController : Controller
    {
        Repository repository = new Repository();
        public IActionResult Read()
        {
            var Users = repository.ReadUsers();
            return View(Users);
        }
        [HttpPost]
        public IActionResult Update(User  user )
        {
            repository.UpdateUser(user);
            return RedirectToAction("Read");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var user = repository.GetIdUser(Id);
            return View(user);
        }
        public IActionResult Delete(int Id)
        {
            repository.DeleteUser(Id);
            return RedirectToAction("Read");
        }
    }
}
