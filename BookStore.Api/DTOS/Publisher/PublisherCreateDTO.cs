using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOS.Publisher
{
    public class PublisherCreateDTO : BaseDto   
    {
      [Required]
      [StringLength(150)]
      public string? Name { get; set; }
    }
}