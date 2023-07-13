using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext()  {}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
    }
}
