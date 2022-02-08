using Microsoft.EntityFrameworkCore;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.Data.Ef
{
    public class EfContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }

        public EfContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=BooksManager_dev;Trusted_Connection=true");
        }

    }
}