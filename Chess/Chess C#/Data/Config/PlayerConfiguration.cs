using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chess_C_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Chess_C_.Data.Config
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()").IsRequired();
            
            builder.Property(x => x.FirstName)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.UserName)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Street)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.State)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.ZipCode)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.City)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Country)
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.AccountStatus).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired().HasConversion(
                v => v.ToString(),
                v => (AccountStatus)Enum.Parse(typeof(AccountStatus), v)
            );

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasCheckConstraint("CK_PLAYER_ZIPCODE", "LEN(ZipCode) = 5 OR LEN(ZipCode) = 9");
            builder.HasCheckConstraint("CK_ACCOUNT_STATUS", "AccountStatus IN ('ACTIVE', 'BANNED', 'BLOCKED')");

            builder.HasMany(x => x.SendInvitations).WithOne(x => x.Sender).HasPrincipalKey(x => x.Id)
                   .HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_PLAYER_SEND");

            builder.ToTable(name: "Players", schema: "ChessGame");
        }
    }
}