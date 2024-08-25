using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Invitation
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public InvitationStatus Status { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Player Sender { get; set; } = null!;
        public Player Receiver { get; set; } = null!;
    }
}