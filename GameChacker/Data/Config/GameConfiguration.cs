using GameChacker.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameChacker.Data.Config
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(g=> g.Id).IsRequired();
            builder.Property(g=>g.GameName).IsRequired().HasMaxLength(100);
            builder.Property(g => g.ImageUrl).IsRequired();
            builder.HasOne(c => c.CompletedGames).WithMany()
                .HasForeignKey(g=>g.CompletedGameId);
            builder.HasOne(p => p.Platform).WithMany()
                .HasForeignKey(g => g.PlatformID);
        }
    }
}
