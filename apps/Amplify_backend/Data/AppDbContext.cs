using Amplify_backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Amplify_backend.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Artists> Artists { get; set; }

        public DbSet<Albums> Albums { get; set; }

        public DbSet<Songs> Songs { get; set; }

        public DbSet<Playlists> Playlists { get; set; }

        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }

        public DbSet<LikedSongs> LikedSongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Local");

            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LikedSongs>(entity =>
            {
                entity.ToTable("liked_songs");
                entity.HasKey(e => new { e.userId, e.songId });
            });

            modelBuilder.Entity<PlaylistSongs>(entity =>
            {
                entity.ToTable("playlist_songs");
                entity.HasKey(e => new { e.playlistId, e.songId });
            });
        }
    }
}
