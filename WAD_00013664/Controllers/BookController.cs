using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_00013664.Data;
using WAD_00013664.Models;
using WAD_00013664.Repositories;

namespace WAD_00013664.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _dbContext;
        public BookController(IRepository<Book> dbContext) 
        {
            _dbContext = dbContext;
        }

        //get all books
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAll()=>
            await _dbContext.GetAllAsync();
        

        //get by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _dbContext.GetByIDAsync(id);
            return result == null ? NotFound(): Ok(result);
        }

        //create a book
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(Book book)
        {
            
            await _dbContext.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new {id = book.BookId}, book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (!id.Equals(book.BookId))
            {
                return BadRequest();
            }
            await _dbContext.UpdateAsync(book);
            return NoContent();


        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {

            await _dbContext.DeleteAsync(id);
            return NoContent();
        }
    }
}
