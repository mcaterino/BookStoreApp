using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Api.Data;
using BookStore.Api.Models;
using BookStore.Api.DTOS.Author;
using AutoMapper;
using BookStore.Api.DTOS.Book;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDTO>>> GetAuthors()
        {
            if (_context.Authors is null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.ToListAsync();
            var authorDtos = _mapper.Map<IEnumerable<AuthorReadOnlyDTO>>(authors);
            return Ok(authorDtos);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadOnlyDTO>> GetAuthor(int id)
        {
            if (_context.Authors is null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);

            if (author is null)
            {
                return NotFound();
            }

            var authorDto = _mapper.Map<AuthorReadOnlyDTO>(author);
            return Ok(authorDto);
        }

        // GET: api/Authors/5/Books
        [HttpGet("{id}/Books")]
        public async Task<ActionResult<IEnumerable<BookReadOnlyDTO>>> GetBooksOfAuthor(int id)
        {
            if (_context.Authors is null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .Include(a => a.AuthorBooks)
                    .ThenInclude(ab => ab.Book)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author is null)
            {
                return NotFound();
            }

            var bookDtos = _mapper.Map<IEnumerable<BookReadOnlyDTO>>(author.AuthorBooks.Select(ab => ab.Book));
            return Ok(bookDtos);
        }
        
        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDTO authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            _mapper.Map(authorDto, author);
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorCreateDTO>> PostAuthor(AuthorCreateDTO authorDto)
        {
          if (_context.Authors is null)
          {
              return Problem("Entity set 'AppDbContext.Authors'  is null.");
          }

            var author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
