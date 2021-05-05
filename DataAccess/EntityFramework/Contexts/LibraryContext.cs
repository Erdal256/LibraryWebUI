using Core.DataAccess.Configs;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionConfig.ConnectionString = "server=DESKTOP-VQ9N1P0\\SEKHARSQL; " +
            //"database=LibraryDB;user id=sa;password=Erdal256;multipleactiveresultsets=true;";
            optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .HasMany(category => category.Books)
            //    .WithOne(Book => Book.Category)
            //    .HasForeignKey(book => book.CategoryId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>()
                .HasOne(book => book.Category)
                .WithMany(category => category.Books)
                .HasForeignKey(book => book.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>()
                .HasOne(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(city => city.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
               .HasOne(user => user.Role)
               .WithMany(role => role.Users)
               .HasForeignKey(user => user.RoleId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDetail>()
                .HasOne(userDetail => userDetail.Country)
                .WithMany(country => country.UserDetails)
                .HasForeignKey(userDetail => userDetail.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDetail>()
                .HasOne(userDetail => userDetail.City)
                .WithMany(city => city.UserDetails)
                .HasForeignKey(userDetail => userDetail.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(user => user.UserDetail)
                .WithOne(userDetail => userDetail.User)
                .HasForeignKey<User>(user => user.UserDetailId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDetail>()
                .HasIndex(userDetail => userDetail.EMail)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .HasIndex(book => book.Name);
        }
    }
}
