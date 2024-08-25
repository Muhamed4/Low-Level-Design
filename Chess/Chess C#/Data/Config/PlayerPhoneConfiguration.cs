using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess_C_.Data.Config
{
    public class PlayerPhoneConfiguration : IEntityTypeConfiguration<PlayerPhone>
    {
        public void Configure(EntityTypeBuilder<PlayerPhone> builder)
        {
            builder.HasKey(x => new { x.PlayerId, x.Phone });
            builder.Property(x => x.Phone).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired();
            builder.HasOne(x => x.Player).WithMany(x => x.Phones).HasForeignKey(x => x.PlayerId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(name: "PlayerPhones", schema: "ChessGame");
        }
    }
}