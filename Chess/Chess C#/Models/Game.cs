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
        public Board Board { get; set; }
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
        public virtual ICollection<PlayerGame> PlayerGames { get; set; } = new List<PlayerGame>();
        public virtual ICollection<Move>? Moves{ get; set; } = new List<Move>();

        public Game()
        {
            Status = GameStatus.ACTIVE;
            Board = new Board();
        }
    }
}