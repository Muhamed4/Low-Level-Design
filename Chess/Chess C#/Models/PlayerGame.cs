using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class PlayerGame
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
        public Player Player { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}