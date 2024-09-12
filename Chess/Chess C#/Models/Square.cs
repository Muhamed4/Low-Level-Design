using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Square
    {
        public char SquareRow { get; set; }
        public char SquareColumn { get; set; }
        public SquareStatus SquareStatus { get; set; }
        public Piece? Piece { get; set; }
        public Square(char squareRow, char squareColumn, SquareStatus squareStatus, Piece? piece = null) {
            SquareRow = squareRow;
            SquareColumn = squareColumn;
            SquareStatus = squareStatus;
            Piece = piece;
        }

        public SquareStatus GetSquareStatus() => SquareStatus;
        public bool HasPiece() => Piece is null ? false : true;
    }
}