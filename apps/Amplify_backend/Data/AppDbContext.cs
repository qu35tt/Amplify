using Amplify_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Amplify_backend.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Local");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
