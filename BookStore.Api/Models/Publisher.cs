namespace BookStore.Api.Models
{
    public class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation Properties 
        public virtual ICollection<Book>? Books { get; } = new List<Book>();
    }
}
