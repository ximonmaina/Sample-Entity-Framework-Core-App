using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Test.TestHelpers;

namespace MyFirstEfCoreApp.HelperExtensions
{
    public static class DatabaseStartupHelpers
    {
        public static async Task SetupDatabaseAsync(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                try
                {
                    var arePendingMigrations = context.Database.GetPendingMigrations().Any();
                    await context.Database.MigrateAsync();
                    if (context.Books.Count() <= 0)
                    {
                        await context.SeedDatabaseFourBooksAsync();
                    }
                }catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error has occurred while trying to create/migrate or seed the database");
                    throw;
                }
            }

            
        }
    }
}
