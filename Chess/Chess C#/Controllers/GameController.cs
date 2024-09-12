using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Data;
using Chess_C_.Models;

namespace Chess_C_.Controllers
{
    public class GameController
    {
        private readonly Game _game;
        private readonly AppDbContext _appDbContext;
        public GameController(AppDbContext appDbContext, Game game) {
            _appDbContext = appDbContext;
            _game = game;
        }

        public void GameIsOver() {
            throw new NotImplementedException();
        }

        public Task<bool> OfferDraw(PieceColor pieceColor) {
            throw new NotImplementedException();
        }

        public async Task Resign(PieceColor pieceColor) {
            await Task.Run(() => {
                if(pieceColor == PieceColor.WHITE)
                    _game.Status = GameStatus.BLACK_WIN;
                else 
                    _game.Status = GameStatus.WHITE_WIN;
                GameIsOver();
            });
        }

        public async Task<bool> CreateNewMove(Guid playerId, Square fromSquare, Square toSquare) {
            throw new NotImplementedException();
        }

        public Task MovePiece(Square fromSquare, Square toSquare) {
            throw new NotImplementedException();
        }

        public Task<bool> MakeCastling(PieceColor pieceColor) {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidMove(Square fromSquare, Square toSquare) {
            throw new NotImplementedException();
        }

        public Task<bool> IsKingUnderAttack(PieceColor pieceColor, Square kingSquare) {
            throw new NotImplementedException();
        }

        public Task<bool> IsCastling(PieceColor pieceColor) {
            throw new NotImplementedException();
        }

        public Task<bool> IsCheckMate(PieceColor pieceColor, Square kingSquare) {
            throw new NotImplementedException();
        }
    }
}