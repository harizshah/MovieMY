// This line gives access to the Genre class from the MovieAPI.Entities namespace
using MovieAPI.Entities;

namespace MovieAPI
{
    // This class simulates a data source that keeps information in memory.
    // It does not connect to a real database yet.
    public class InMemoryRepository
    {
        // A private list that holds Genre objects in memory
        private List<Genre> _genres;

        // Constructor: runs automatically when a new InMemoryRepository object is created
        public InMemoryRepository()
        {
            // Create a list of genres and add two sample records
            _genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Comedy" },
                new Genre { Id = 2, Name = "Action" }
            };
        }

        // This method returns all the genres from the list
        public List<Genre> GetAllGenres()
        {
            return _genres;
        }

        // This asynchronous method finds a genre by its Id
        public async Task<Genre?> GetById(int id)
        {
            // Simulate a delay of 3 seconds to mimic a slow operation (like a database call)
            await Task.Delay(TimeSpan.FromSeconds(3));

            // Find and return the first genre with the matching Id, or null if not found
            return _genres.FirstOrDefault(g => g.Id == id);
        }
        
        private async Task MyPrivateMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
}