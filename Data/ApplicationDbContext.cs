using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string ConnectionString = "Server=MAINA;Database=MyFirstEfCoreDb;User Id=Simon;Password=Maina1234;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True";
        public ApplicationDbContext()  {}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public DbSet<Book> Books { get; set; }
    }
}
