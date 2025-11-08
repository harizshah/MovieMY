using System.ComponentModel;
using System.Net;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DTOs;
using MovieAPI.Entities;
using MovieAPI.Services;
using MovieAPI.Utilities;

namespace MovieAPI.Controllers
{
    [Route("api/actors")]
    [ApiController] 
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IFileStorage fileStorage;
        private const string cacheTag = "Actors";
        private readonly string container = "Actors";

        public ActorsController(ApplicationDbContext context, IMapper mapper,
            IOutputCacheStore outputCacheStore, IFileStorage fileStorage)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
            this.fileStorage = fileStorage;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<ActorDTO>> Get([FromQuery] PaginationDTO pagination)
        {
            var queryable = context.Actors;
            await HttpContext.InsertPaginationParametersInHeader(queryable);
            return await queryable
                .OrderBy(a => a.Name)
                .Paginate(pagination)
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        
        [HttpGet("{id:int}", Name = "GetActorById")]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Actors
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null)
            {
                return NotFound();
            }
            
            return actor;
        }
            
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ActorCreationDTO actorCreationDto)
        {
            var actor = mapper.Map<Actor>(actorCreationDto);

            if (actorCreationDto.Picture is not null)
            {
                var url = await fileStorage.Store(container, actorCreationDto.Picture);
                actor.Picture = url;
            }
            
            context.Add(actor);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            var actorDTO = mapper.Map<ActorDTO>(actor);
            return CreatedAtRoute("GetActorById", new { id = actor.Id }, actor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] ActorCreationDTO actorCreationDto)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            if (actor is null)
            {
                return NotFound();
            }
            
            actor = mapper.Map(actorCreationDto, actor);

            if (actorCreationDto.Picture is not null)
            {
                actor.Picture = await fileStorage.Edit(actor.Picture, container, actorCreationDto.Picture);
            }

            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            if (actor is null)
            {
                return NotFound();
            }

            context.Remove(actor);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            await fileStorage.Delete(actor.Picture,container);
            return NoContent();
        }
    }
}