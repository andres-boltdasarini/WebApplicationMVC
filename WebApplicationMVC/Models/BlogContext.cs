using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models.Db;

namespace WebApplicationMVC.Models
{
    public sealed class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<LogRequest> LogRequests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}