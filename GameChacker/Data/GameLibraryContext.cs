using GameChacker.Entites;
using Microsoft.EntityFrameworkCore;

namespace GameChacker.Data
{
    public class GameLibraryContext : DbContext
    {
        public GameLibraryContext(DbContextOptions<GameLibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
    }
}
