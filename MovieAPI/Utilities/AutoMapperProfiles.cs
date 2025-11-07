using MovieAPI.DTOs;
using AutoMapper;
using MovieAPI.Entities;

namespace MovieAPI.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            ConfigureGenres();
        }

        private void ConfigureGenres()
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<Genre, GenreDTO>();
        }
    }
}