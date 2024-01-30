using Microsoft.EntityFrameworkCore;
using WAD_00013664.Data;
using WAD_00013664.Models;

namespace WAD_00013664.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookCatalogDbContext _context;

        public BookRepository(BookCatalogDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (item != null)
            {
                _context.Books.Remove(item);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();


        public async Task<Book> GetByIDAsync(int id) =>
        await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);


        public async Task UpdateAsync(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
