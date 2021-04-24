using Core.DataAccess.Configs;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionConfig.ConnectionString = "server=DESKTOP-VQ9N1P0\\SEKHARSQL; " +
            //"database=LibraryDB;user id=sa;password=Erdal256;multipleactiveresultsets=true;";
            optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(category => category.Books)
                .WithOne(Book => Book.Category)
                .HasForeignKey(book => book.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
