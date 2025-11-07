using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MovieAPI.DTOs;
using MovieAPI.Entities;

namespace MovieAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController: ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "genres";

        public GenresController(IOutputCacheStore outputCacheStore, ApplicationDbContext context,
            IMapper  mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/genres
        [OutputCache(Tags = [cacheTag])]
        public List<Genre> Get()
        {
            return new List<Genre>
            {
                new Genre() {Id = 1, Name = "Action"},
                new Genre() {Id = 2, Name = "Drama"},
            };
        }

        [HttpGet("{id:int}", Name = "GetGenreById")] // api/genres/500
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Genre>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post([FromBody] GenreCreationDTO genreCreationDto)
        {
            var genre = mapper.Map<Genre>(genreCreationDto);
            context.Add(genre);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            var genreDTO = mapper.Map<GenreDTO>(genre);
            return CreatedAtRoute("GetGenreById", new { id = genreDTO.Id }, genreDTO);
        }
        
        
        
    }
}