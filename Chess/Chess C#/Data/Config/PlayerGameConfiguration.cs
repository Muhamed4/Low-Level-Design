using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess_C_.Data.Config
{
    public class PlayerGameConfiguration : IEntityTypeConfiguration<PlayerGame>
    {
        public void Configure(EntityTypeBuilder<PlayerGame> builder)
        {
            builder.HasKey(x => new { x.PlayerId, x.GameId });
            builder.HasOne(x => x.Player).WithMany(x => x.PlayerGames).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.PlayerId)
                   .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_PLAYER_PLAYER_GAME");
            builder.HasOne(x => x.Game).WithMany(x => x.PlayerGames).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.GameId)
                   .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_GAME_PLAYER_GAME");
            builder.ToTable(name: "PlayerGames", schema: "ChessGame");
        }
    }
}