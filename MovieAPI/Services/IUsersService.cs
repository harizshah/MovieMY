namespace MovieAPI.Services
{
    public interface IUsersService
    {
        Task<string> GetUserId();
    }
}