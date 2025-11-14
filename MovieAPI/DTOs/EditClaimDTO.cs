using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class EditClaimDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}