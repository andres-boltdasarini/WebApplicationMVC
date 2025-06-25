using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models.Db;
using WebApplicationMVC.Repositories;

namespace WebApplicationMVC.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IBlogRepository _repo;

        // Также добавим инициализацию в конструктор
        public RegisterController(IBlogRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Users/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            user.Id = Guid.NewGuid();
            user.JoinDate = DateTime.Now;

            await _repo.AddUser(user);

            return Content($"Регистрация прошла успешно, {user.FirstName}!");
        }
    }
}
