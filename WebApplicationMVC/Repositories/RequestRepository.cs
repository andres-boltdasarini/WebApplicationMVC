using WebApplicationMVC.Models;
using WebApplicationMVC.Models.Db;

namespace WebApplicationMVC.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task LogRequestAsync(string url)
        {
            var logEntry = new LogRequest
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = url
            };

            _context.LogRequests.Add(logEntry);
            await _context.SaveChangesAsync();
        }
    }
}