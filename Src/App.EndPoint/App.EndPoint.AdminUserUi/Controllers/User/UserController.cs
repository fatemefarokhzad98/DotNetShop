using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.User
{
    public class UserController : Controller
    {
        private readonly ProductRepository repository;
        public UserController(ProductRepository _repository)
        {
            repository = _repository;

        }
        public IActionResult Read()
        {
            var Users = repository.ReadUsers();
            return View("Read", Users);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            repository.UpdateUser(user);
            return RedirectToAction("Read");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var user = repository.GetIdUser(Id);
            return View("Update", user);
        }
        public IActionResult Delete(int Id)
        {
            repository.DeleteUser(Id);
            return RedirectToAction("Read");
        }
    }
}
