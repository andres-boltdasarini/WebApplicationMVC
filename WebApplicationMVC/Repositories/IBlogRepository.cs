using WebApplicationMVC.Models.Db;

namespace WebApplicationMVC.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
