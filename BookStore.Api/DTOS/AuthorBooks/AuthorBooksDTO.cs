namespace BookStore.Api.DTOS.AuthorBooks
{
    public class AuthorBooksDTO : BaseDto
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
    }
}