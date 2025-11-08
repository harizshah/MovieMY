using MovieAPI.DTOs;
using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Entities
{
    public class Genre: IId
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must fill the {0} field")]
        [StringLength(maximumLength: 50)]
        [FirstLetterUppercase]
        public required string Name { get; set; }
    }
}