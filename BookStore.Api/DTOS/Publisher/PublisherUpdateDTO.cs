using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOS.Publisher
{
    public class PublisherUpdateDTO : BaseDto
    {
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
    }
}