using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOS.Publisher
{
    public class PublisherReadOnlyDTO : BaseDto
    {
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
    }
}