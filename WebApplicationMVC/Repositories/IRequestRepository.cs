namespace WebApplicationMVC.Repositories
{
    public interface IRequestRepository
    {
        Task LogRequestAsync(string url);
    }
}