using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTOS.Book
{
    public class BookUpdateDTO : BaseDto
    {
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Required]
        public int? Year { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public string Isbn { get; set; } = null!;

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string? Summary { get; set; }

        public string? Image { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal? Price { get; set; }
    }
}
