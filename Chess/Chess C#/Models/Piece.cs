using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public abstract class Piece
    {
        protected PieceType PieceType { get; set; }
        protected PieceColor PieceColor { get; set; }
        protected PieceStatus PieceStatus { get; set; }
        protected PieceRank PieceRank { get; set; }
        protected List<int>? RowDirections;
        protected List<int>? ColumnDirections;
        public abstract PieceType GetPieceType();
        public abstract PieceColor GetPieceColor();
        public abstract PieceStatus GetPieceStatus();
        public abstract PieceRank GetRank();
        public abstract void SetPieceStatus(PieceStatus pieceStatus);
    }
}