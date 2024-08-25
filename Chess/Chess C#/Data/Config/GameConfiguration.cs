using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess_C_.Data.Config
{
    [Obsolete]
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.Date).HasDefaultValueSql("SYSDATETIME()").IsRequired();
            builder.Property(x => x.Status).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired().HasConversion(
                v => v.ToString(),
                v => (GameStatus)Enum.Parse(typeof(GameStatus), v)
            );
            builder.HasMany(x => x.Players).WithMany(x => x.Games).UsingEntity<PlayerGame>();
            builder.HasCheckConstraint("CK_GAME_STATUS", "Status IN ('ACTIVE', 'WHITE_WIN', 'BLACK_WIN', 'DRAW', 'RESIGN')");
            builder.ToTable(name: "Games", schema: "ChessGame");
        }
    }
}