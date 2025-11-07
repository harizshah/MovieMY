using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}