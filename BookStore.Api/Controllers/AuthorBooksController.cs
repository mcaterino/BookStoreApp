using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Api.Data;
using BookStore.Api.Models;
using AutoMapper;
using BookStore.Api.DTOS.AuthorBooks;
using AutoMapper.QueryableExtensions;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorBooksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST: api/AuthorBooks
        [HttpPost]
        public async Task<ActionResult<AuthorBooksDTO>> PostAuthorBooks(AuthorBooksDTO authorBooksDTO)
        {
            var author = await _context.Authors.FindAsync(authorBooksDTO.AuthorId);
            if (author is null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(authorBooksDTO.BookId);
            if (book is null)
            {
                return NotFound();
            }

            var authorBook = new AuthorBook
            {
                AuthorId = authorBooksDTO.AuthorId,
                BookId = authorBooksDTO.BookId
            };

            _context.AuthorBooks.Add(authorBook);
            await _context.SaveChangesAsync();

           //return CreatedAtAction("GetAuthorBooks", new { id = authorBook.Id }, _mapper.Map<AuthorBooksDTO>(authorBook));
           return Ok(_mapper.Map<AuthorBooksDTO>(authorBook));
        }

        // DELETE: api/AuthorBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorBooks(int id)
        {
            var authorBook = await _context.AuthorBooks.FindAsync(id);
            if (authorBook is null)
            {
                return NotFound();
            }

            _context.AuthorBooks.Remove(authorBook);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }      
}