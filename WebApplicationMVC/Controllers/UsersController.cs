using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models.Db;
using WebApplicationMVC.Repositories;

namespace WebApplicationMVC.Controllers
{
    public class UsersController : Controller
    {

        private readonly IBlogRepository _repo;

        // Также добавим инициализацию в конструктор
        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

       [HttpPost]
       public async Task <IActionResult> Register (User newUser)
       {
           await _repo.AddUser(newUser);
           return View(newUser);
       }
    }
}
