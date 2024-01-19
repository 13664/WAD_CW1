using Microsoft.EntityFrameworkCore;

namespace WAD_00013664.Data
{
    public class BookCatalogDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
       

        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
             .HasOne(b => b.Category)
             .WithMany(c => c.Books)
             .HasForeignKey(b => b.CategoryId);
        }
       
    }
}
