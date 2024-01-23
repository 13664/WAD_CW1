using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_00013664.Data;
using WAD_00013664.Models;

namespace WAD_00013664.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BookCatalogDbContext _dbContext;

        public CategoryController(BookCatalogDbContext bookCatalogDbContext)
        {
            _dbContext = bookCatalogDbContext;
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _dbContext.Categories.ToListAsync();
            return Ok(result);
        }
        /// <summary>
        /// get category by id 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
       // [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);

        }

        /// <summary>
        /// create a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(category == null)
            {
                return BadRequest();
            }   

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();    
            
            return CreatedAtAction(nameof(GetById), new {id = category.Id}, category);
        }

        /// <summary>
        /// modifying tha state of tha category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (!id.Equals(category.Id))
            {
                return BadRequest();
            }
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }
        /// <summary>
        /// delete the category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }

    }
}
