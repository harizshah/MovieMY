// This allows access to ASP.NET Core MVC features like [HttpGet], [HttpPost], etc.
using Microsoft.AspNetCore.Mvc;

// This allows access to the Genre class inside MovieAPI.Entities
using MovieAPI.Entities;
using Microsoft.AspNetCore.OutputCaching;

namespace MovieAPI.Controllers
{
    // This sets the base URL path for this controller.
    // So the endpoint will start with "api/genres"
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        // This method handles HTTP GET requests (when someone tries to read data)
        [HttpGet("all-genres")] // api/genres/all-genres
        [HttpGet] // api/genres
        [HttpGet("/all-of-the-genres")] // /all-of-the-genres
        public List<Genre> Get()
        {
            // Create a new instance of the InMemoryRepository class
            var repository = new InMemoryRepository();

            // Call the GetAllGenres() method to get all genre data
            var genres = repository.GetAllGenres();

            // Return the list of genres to the client
            return genres;
        }

        [HttpGet("{id:int}")] // api/genres/500
        [OutputCache]
        public async Task<ActionResult<Genre>> Get(int id)
        {
            var repository = new InMemoryRepository();
            var genre =  await repository.GetById(id);

            if (genre is null)
            {
                return NotFound();
            }

            return genre;
        }

        // This method handles HTTP POST requests (used for creating new data)
        [HttpPost]
        public void Post()
        {
            // Empty for now — later will add logic to add a new genre
        }

        // This method handles HTTP PUT requests (used for updating data)
        [HttpPut]
        public void Put()
        {
            // Empty for now — later will add logic to update a genre
        }

        // This method handles HTTP DELETE requests (used for deleting data)
        [HttpDelete]
        public void Delete()
        {
            // Empty for now — later will add logic to delete a genre
        }
    }
}