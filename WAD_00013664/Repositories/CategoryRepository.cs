using Microsoft.EntityFrameworkCore;
using WAD_00013664.Data;
using WAD_00013664.Models;

namespace WAD_00013664.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BookCatalogDbContext _context;
        public CategoryRepository(BookCatalogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<Category>> GetAllAsync()=>
        await _context.Categories.ToListAsync();
        

        public async Task<Category> GetByIDAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
