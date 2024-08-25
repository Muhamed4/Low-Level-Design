using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public GameStatus Status { get; set; }
        public ICollection<Player> Players { get; set; } = null!;
        public ICollection<PlayerGame> PlayerGames { get; set; } = null!;
        public ICollection<Move>? Moves{ get; set; }
    }
}