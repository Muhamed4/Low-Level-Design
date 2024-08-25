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
    public class MoveConfiguration : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FromSquareRow).HasColumnType("CHAR").HasMaxLength(1).IsRequired();
            builder.Property(x => x.FromSquareColumn).HasColumnType("CHAR").HasMaxLength(1).IsRequired();
            builder.Property(x => x.ToSquareRow).HasColumnType("CHAR").HasMaxLength(1).IsRequired();
            builder.Property(x => x.ToSquareColumn).HasColumnType("CHAR").HasMaxLength(1).IsRequired();
            builder.Property(x => x.PieceType).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired().HasConversion(
                v => v.ToString(),
                v => (PieceType)Enum.Parse(typeof(PieceType), v)
            );
            builder.Property(x => x.PieceColor).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired().HasConversion(
                v => v.ToString(),
                v => (PieceColor)Enum.Parse(typeof(PieceColor), v)
            );
            builder.Property(x => x.KilledPieceType).HasColumnType("NVARCHAR").HasMaxLength(20).HasConversion(
                v => v.HasValue ? v.Value.ToString() : null,
                v => v != null ? (PieceType)Enum.Parse(typeof(PieceType), v) : null
            );
            builder.Property(x => x.IsCastling).HasColumnType("BIT").IsRequired();
            builder.HasCheckConstraint("CK_PIECE_TYPE", "PieceType IN ('PAWN', 'BISHOP', 'KNIGHT', 'ROOK', 'QUEEN', 'KING')");
            builder.HasCheckConstraint("CK_PIECE_COLOR", "PieceColor IN ('WHITE', 'BLACK')");
            builder.HasCheckConstraint("CK_KILLED_PIECE_TYPE", "[KilledPieceType] IS NULL OR [KilledPieceType] IN ('PAWN', 'BISHOP', 'KNIGHT', 'ROOK', 'QUEEN', 'KING')");
            builder.HasOne(x => x.Player).WithMany(x => x.Moves).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.PlayerId)
                   .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_PLAYER_MOVE");
            builder.HasOne(x => x.Game).WithMany(x => x.Moves).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.GameId)
                   .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_GAME_MOVE");
            builder.ToTable(name: "Moves", schema: "ChessGame");
        }
    }
}