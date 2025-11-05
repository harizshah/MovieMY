using MovieAPI.Entities;

namespace MovieAPI
{
    public interface IRepository
    {
        List<Genre> GetAllGenres();
        Task<Genre?> GetById(int id);
        bool Exists(string name);
        int Create(Genre genre);
    }
}