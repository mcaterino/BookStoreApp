using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.DTOS.Publisher;
using BookStore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly AppDbContext? _context;
        private readonly IMapper? _mapper;

        public PublishersController(AppDbContext? context, IMapper? mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Publishers
        [HttpGet]
        public IActionResult GetPublishers()
        {
            if (_context?.Publishers is null)
            {
                return NotFound();
            }

            var publishers = _context.Publishers;
            var publisherDtos = _mapper?.Map<IEnumerable<PublisherReadOnlyDTO>>(publishers);
            return Ok(publisherDtos);
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public IActionResult GetPublisher(int id)
        {
            if (_context?.Publishers is null)
            {
                return NotFound();
            }

            var publisher = _context.Publishers.Find(id);

            if (publisher is null)
            {
                return NotFound();
            }

            var publisherDto = _mapper?.Map<PublisherReadOnlyDTO>(publisher);
            return Ok(publisherDto);
        }

        // POST: api/Publishers/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublisherCreateDTO>> PostPublisher(PublisherCreateDTO publisherDto)
        {
            if (_context?.Publishers is null)
            {
                return Problem("Entity set 'AppDbContext.Publisher'  is null.");
            }

            var publisher = _mapper?.Map<Publisher>(publisherDto);
            if (publisher == null)
            {
                return BadRequest("Unable to map the provided publisherDto to a Publisher entity.");
            }

            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublisher", new { id = publisher.Id }, publisher);
        }

        // PUT: api/Publisher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(int id, PublisherUpdateDTO publisherDto)
        {
            if (id != publisherDto.Id)
            {
                return BadRequest();
            }

            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            _mapper.Map(publisherDto, publisher);
            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // DELETE: api/Publisher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherExists(int id)
        {
            return (_context.Publishers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
