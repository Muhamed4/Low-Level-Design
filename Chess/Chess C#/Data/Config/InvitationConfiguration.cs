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
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(x => x.Date).HasDefaultValueSql("SYSDATETIME()").IsRequired();
            builder.Property(x => x.Status).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired().HasConversion(
                v => v.ToString(),
                v => (InvitationStatus)Enum.Parse(typeof(InvitationStatus), v)
            );
            builder.HasCheckConstraint("CK_INVITATION_STATUS", "Status IN ('ACTIVE, ACCEPTED, CANCELLED')");
            builder.HasOne(x => x.Receiver).WithMany(x => x.ReceiveInvitations).HasPrincipalKey(x => x.Id)
                   .HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_PLAYER_RECEIVE");

            builder.ToTable(name: "Invitations", schema: "ChessGame");
        }
    }
}