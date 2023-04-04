using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOS.Author
{
    public class AuthorCreateDTO    
    {
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(250)]
        public string? Bio { get; set; }
    }
}
