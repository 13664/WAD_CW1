using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_00013664.Data;
using WAD_00013664.Models;

namespace WAD_00013664.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookCatalogDbContext _dbContext;
        public BookController(BookCatalogDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        //get all books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =  await _dbContext.Books.ToListAsync();
            return Ok(result);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == id);
            return Ok(book);
        }

        //create a book
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if(book == null)
            {
                return BadRequest();
            }
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Book), new {id = book.BookId}, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (!id.Equals(book.BookId))
            {
                return BadRequest();
            }
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();


        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (item == null)
            {
                return BadRequest();
            }
            _dbContext.Books.Remove(item);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
