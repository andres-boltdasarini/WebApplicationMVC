using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVC.Models;
using WebApplicationMVC.Models.Db;

namespace WebApplicationMVC.Controllers
{
    public class RequestHistoryController : Controller
    {
        private readonly BlogContext _context;

        public RequestHistoryController(BlogContext context)
        {
            _context = context;
        }

        // GET: /request-history
        public async Task<IActionResult> Index()
        {
            var logs = await _context.LogRequests
                .OrderByDescending(l => l.Date)
                .Take(200)
                .ToListAsync();

            return View(logs);
        }
    }
}