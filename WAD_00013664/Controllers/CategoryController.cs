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
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category>  _repository;

        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _repository.GetAllAsync();
        }
        /// <summary>
        /// get category by id 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("{id:Guid}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _repository.GetByIDAsync(id);
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
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(Category category)
        {
            if(category == null)
            {
                return BadRequest();
            }

            await _repository.AddAsync(category);  
            
            return CreatedAtAction(nameof(GetById), new {id = category.Id}, category);
        }

        /// <summary>
        /// modifying tha state of tha category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (!id.Equals(category.Id))
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(category);
            return NoContent();

        }
        /// <summary>
        /// delete the category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

    }
}
