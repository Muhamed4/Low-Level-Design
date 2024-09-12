using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Pawn: Piece
    {
        public Pawn(PieceColor pieceColor, PieceRank rank)
        {
            PieceType = PieceType.PAWN;
            PieceColor = pieceColor;
            PieceStatus = PieceStatus.FIGHT;
            PieceRank = rank;
        }
        public override PieceColor GetPieceColor() => PieceColor;

        public override PieceStatus GetPieceStatus() => PieceStatus;

        public override PieceType GetPieceType() => PieceType;

        public override PieceRank GetRank() => PieceRank;

        public override void SetPieceStatus(PieceStatus pieceStatus) => PieceStatus = pieceStatus;
    }
}