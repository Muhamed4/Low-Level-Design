using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class Board
    {
        public Square[,] Squares { get; private set; }
        public List<Piece>? WhitePieces { get; private set; }
        public List<Piece>? BlackPieces { get; private set; }

        public Board()
        {
            Squares = new Square[9,9];
            InitializeWhitePieces();
            InitializeBlackPieces();
            InitializeSquares();
        }

        public Square GetSquare(char row, char col) {
            if(row < '1' || row > '8' || col < 'a' || col < 'h')
                throw new ArgumentOutOfRangeException("The row and column is not a valid position in the board!");
            var square = Squares[row - '0', col - 'a' + 1];
            return square;
        }

        public Piece GetPiece(char row, char col) {
            if(row < '1' || row > '8' || col < 'a' || col < 'h')
                throw new ArgumentOutOfRangeException("The row and column is not a valid position in the board!");
            var square = Squares[row - '0', col - 'a' + 1];
            if(square.Piece is null)
                throw new ArgumentNullException("There is no piece at this square");
            return square.Piece;
        }

        public List<Piece> GetAllPieces(PieceColor pieceColor) {
            List<Piece> pieces = new List<Piece>();
            switch (pieceColor)
            {
                case PieceColor.WHITE:
                    pieces = WhitePieces;
                    break;
                case PieceColor.BLACK:
                    pieces = BlackPieces;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("This color is not valid!");
            }

            return pieces;
        }

        private void InitializeBlackPieces()
        {
            WhitePieces = new List<Piece>() 
            {
                new Pawn(PieceColor.BLACK, PieceRank.ONE),
                new Pawn(PieceColor.BLACK, PieceRank.TWO),
                new Pawn(PieceColor.BLACK, PieceRank.THREE),
                new Pawn(PieceColor.BLACK, PieceRank.FOUR),
                new Pawn(PieceColor.BLACK, PieceRank.FIVE),
                new Pawn(PieceColor.BLACK, PieceRank.SIX),
                new Pawn(PieceColor.BLACK, PieceRank.SEVEN),
                new Pawn(PieceColor.BLACK, PieceRank.EIGHT),
                new Rook(PieceColor.BLACK, PieceRank.ONE),
                new Rook(PieceColor.BLACK, PieceRank.TWO),
                new Knight(PieceColor.BLACK, PieceRank.ONE),
                new Knight(PieceColor.BLACK, PieceRank.TWO),
                new Bishop(PieceColor.BLACK, PieceRank.ONE),
                new Bishop(PieceColor.BLACK, PieceRank.TWO),
                new Queen(PieceColor.BLACK),
                new King(PieceColor.BLACK)
            };
        }

        private void InitializeWhitePieces()
        {
            WhitePieces = new List<Piece>() 
            {
                new Pawn(PieceColor.WHITE, PieceRank.ONE),
                new Pawn(PieceColor.WHITE, PieceRank.TWO),
                new Pawn(PieceColor.WHITE, PieceRank.THREE),
                new Pawn(PieceColor.WHITE, PieceRank.FOUR),
                new Pawn(PieceColor.WHITE, PieceRank.FIVE),
                new Pawn(PieceColor.WHITE, PieceRank.SIX),
                new Pawn(PieceColor.WHITE, PieceRank.SEVEN),
                new Pawn(PieceColor.WHITE, PieceRank.EIGHT),
                new Rook(PieceColor.WHITE, PieceRank.ONE),
                new Rook(PieceColor.WHITE, PieceRank.TWO),
                new Knight(PieceColor.WHITE, PieceRank.ONE),
                new Knight(PieceColor.WHITE, PieceRank.TWO),
                new Bishop(PieceColor.WHITE, PieceRank.ONE),
                new Bishop(PieceColor.WHITE, PieceRank.TWO),
                new Queen(PieceColor.WHITE),
                new King(PieceColor.WHITE)
            };
        }

        private void InitializeSquares()
        {
            Squares[1,1] = new Square('1', 'a', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.ROOK 
                                                                                                    && p.GetRank() == PieceRank.ONE));
            Squares[1,2] = new Square('1', 'b', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.KNIGHT 
                                                                                                    && p.GetRank() == PieceRank.ONE));
            Squares[1,3] = new Square('1', 'c', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.BISHOP 
                                                                                                    && p.GetRank() == PieceRank.ONE));
            Squares[1,4] = new Square('1', 'd', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.QUEEN));
            Squares[1,5] = new Square('1', 'e', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.KING));
            Squares[1,6] = new Square('1', 'f', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.BISHOP 
                                                                                                    && p.GetRank() == PieceRank.TWO));
            Squares[1,7] = new Square('1', 'g', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.KNIGHT 
                                                                                                    && p.GetRank() == PieceRank.TWO));
            Squares[1,8] = new Square('1', 'h', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.ROOK 
                                                                                                    && p.GetRank() == PieceRank.TWO));
            Squares[2,1] = new Square('2', 'a', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.ONE));  
            Squares[2,2] = new Square('2', 'b', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.TWO));                                                                                                                                                                             
            Squares[2,3] = new Square('2', 'c', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.THREE));                                                                                                                                                                             
            Squares[2,4] = new Square('2', 'd', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.FOUR));                                                                                                                                                                             
            Squares[2,5] = new Square('2', 'e', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.FIVE));                                                                                                                                                                             
            Squares[2,6] = new Square('2', 'f', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.SIX));                                                                                                                                                                             
            Squares[2,7] = new Square('2', 'g', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.SEVEN));                                                                                                                                                                             
            Squares[2,8] = new Square('2', 'h', SquareStatus.OCCUPIED, WhitePieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.EIGHT));                                                                                                                                                                             

            for(int row = 3; row <= 8; ++row) {
                for(char col = 'a'; col <= 'h'; ++col) {
                    Squares[row, (col - 'a') + 1] = new Square(row.ToString()[0], col, SquareStatus.UNOCCUPIED);
                }
            }


            Squares[8,1] = new Square('8', 'a', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.ROOK 
                                                                                                    && p.GetRank() == PieceRank.ONE));
            Squares[8,2] = new Square('8', 'b', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.KNIGHT 
                                                                                                    && p.GetRank() == PieceRank.ONE));
            Squares[8,3] = new Square('8', 'c', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.BISHOP 
                                                                                                    && p.GetRank() == PieceRank.ONE));
            Squares[8,4] = new Square('8', 'd', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.QUEEN));
            Squares[8,5] = new Square('8', 'e', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.KING));
            Squares[8,6] = new Square('8', 'f', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.BISHOP 
                                                                                                    && p.GetRank() == PieceRank.TWO));
            Squares[8,7] = new Square('8', 'g', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.KNIGHT 
                                                                                                    && p.GetRank() == PieceRank.TWO));
            Squares[8,8] = new Square('8', 'h', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.ROOK 
                                                                                                    && p.GetRank() == PieceRank.TWO));
            Squares[7,1] = new Square('7', 'a', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.ONE));  
            Squares[7,2] = new Square('7', 'b', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.TWO));                                                                                                                                                                             
            Squares[7,3] = new Square('7', 'c', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.THREE));                                                                                                                                                                             
            Squares[7,4] = new Square('7', 'd', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.FOUR));                                                                                                                                                                             
            Squares[7,5] = new Square('7', 'e', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.FIVE));                                                                                                                                                                             
            Squares[7,6] = new Square('7', 'f', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.SIX));                                                                                                                                                                             
            Squares[7,7] = new Square('7', 'g', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.SEVEN));                                                                                                                                                                             
            Squares[7,8] = new Square('7', 'h', SquareStatus.OCCUPIED, BlackPieces.SingleOrDefault(p => p.GetPieceType() == PieceType.PAWN 
                                                                                                    && p.GetRank() == PieceRank.EIGHT));                                                                                                                                                                                                                                                           
        }

        
    }
}