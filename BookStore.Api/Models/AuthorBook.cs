using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public partial class AuthorBook
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
