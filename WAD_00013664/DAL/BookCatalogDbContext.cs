using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WAD_00013664.Models;

namespace WAD_00013664.Data
{
    public class BookCatalogDbContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? Categories { get; set; }
       

        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>()
            //    .HasOne(e => e.Category);
               
        }

    }
}
