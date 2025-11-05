// This line allows access to the Genre class located in the MovieAPI.Entities namespace
using MovieAPI.Entities;

namespace MovieAPI
{
    // This class stores and manages data in memory (no database yet)
    public class InMemoryRepository
    {
        // This is a private list that holds Genre objects
        private List<Genre> _genres;

        // This is the constructor — it runs automatically when the class is created
        public InMemoryRepository()
        {
            // Here we create a new list of Genre and add two sample items to it
            _genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Comedy" },
                new Genre { Id = 2, Name = "Action" }
            };
        }

        // This method returns all the genres in the list
        public List<Genre> GetAllGenres()
        {
            return _genres;
        }
        
        public Genre? GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.Id == id);
        }
    }
}