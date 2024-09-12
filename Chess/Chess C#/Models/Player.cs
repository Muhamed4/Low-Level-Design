using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set;} = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public AccountStatus AccountStatus { get; set; }
        public virtual ICollection<PlayerPhone>? Phones { get; set; } = null!;
        public virtual ICollection<Invitation>? SendInvitations { get; set;}
        public virtual ICollection<Invitation>? ReceiveInvitations { get; set;}
        public virtual ICollection<Move>? Moves { get; set; }
        public virtual ICollection<Game>? Games { get; set; }
        public virtual ICollection<PlayerGame>? PlayerGames { get; set; }
    }
}