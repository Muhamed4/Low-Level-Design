using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Move
    {
        public int Id { get; set; }
        public char FromSquareRow { get; set; }
        public char FromSquareColumn { get; set; }
        public char ToSquareRow { get; set; }
        public char ToSquareColumn { get; set; }
        public PieceType PieceType { get; set; }
        public PieceColor PieceColor { get; set; }
        public PieceType? KilledPieceType { get; set; }
        public bool IsCastling { get; set; }
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
        public Player Player { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}