using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Api.Data;
using BookStore.Api.Models;
using AutoMapper;
using BookStore.Api.DTOS.Book;
using AutoMapper.QueryableExtensions;
using BookStore.Api.DTOS.Author;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadOnlyDTO>>> GetBooks()
        {
            if (_context.Books is null)
            {
                return NotFound();
            }

            var bookDtos = await _context.Books
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Select(b => new 
                {
                    Book = b,
                    AuthorBook = b.AuthorBooks.FirstOrDefault()
                })
                .Select(x => new BookReadOnlyDTO
                {
                    Id = x.Book.Id,
                    Title = x.Book.Title,
                    Image = x.Book.Image,
                    Price = x.Book.Price ?? 0,
                    AuthorId = x.AuthorBook != null ? x.AuthorBook.AuthorId : null,
                    AuthorName = x.AuthorBook != null && x.AuthorBook.Author != null ? x.AuthorBook.Author.FirstName + " " + x.AuthorBook.Author.LastName : "Unknown"
                })
                .ToListAsync();
            return Ok(bookDtos);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBook(int id)
        {
            if (_context.Books is null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Select(b => new 
                {
                    Book = b,
                    AuthorBook = b.AuthorBooks.FirstOrDefault()
                })
                .Select(x => new BookDetailsDTO
                {
                    Id = x.Book.Id,
                    Title = x.Book.Title,
                    Image = x.Book.Image,
                    Price = x.Book.Price ?? 0,
                    AuthorId = x.AuthorBook != null ? x.AuthorBook.AuthorId : null,
                    AuthorName = x.AuthorBook != null && x.AuthorBook.Author != null ? x.AuthorBook.Author.FirstName + " " + x.AuthorBook.Author.LastName : "Unknown"
                })
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        
        // Get: api/Books/5/Authors
        [HttpGet("{id}/Authors")]
        public async Task<ActionResult<IEnumerable<BookReadOnlyDTO>>> GetAuthorsOfBooks(int id)
        {
            var book = await _context.Books.Include(b => b.AuthorBooks)
                .ThenInclude(ab => ab.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            var authorDtos = _mapper.Map<IEnumerable<AuthorReadOnlyDTO>>(book.AuthorBooks.Select(ab => ab.Author));
            return Ok(authorDtos);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookUpdateDTO bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, book);
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookCreateDTO>> PostBook(BookCreateDTO bookDto)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'AppDbContext.Books'  is null.");
          }

          var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> BookExists(int id)
        {
            return await _context.Books.AnyAsync(e => e.Id == id);
        }
    }
}
