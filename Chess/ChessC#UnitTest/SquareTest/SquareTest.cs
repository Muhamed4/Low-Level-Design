using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;

namespace ChessC_UnitTest
{
    public class SquareTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
                char row = '1';
                char col = 'a';
                SquareStatus squareStatus = SquareStatus.OCCUPIED;
                Piece piece = new King(PieceColor.WHITE);
            // Act
                Square sut = new Square(row, col, squareStatus, piece);
            // Assert
                Assert.Equal(row, sut.SquareRow);
                Assert.Equal(col, sut.SquareColumn);
                Assert.Equal(squareStatus, sut.SquareStatus);
                Assert.Equal(piece, sut.Piece); 
        }

        [Fact]
        public void Constructor_WhenPieceNotProvided_ShouldInitializePieceWithNull() {
            // Arrange
                char row = '1';
                char col = 'b';
                SquareStatus squareStatus = SquareStatus.UNOCCUPIED;
            // Act
                Square square = new Square(row, col, squareStatus);
            // Assert
                Assert.Equal(row, square.SquareRow);
                Assert.Equal(col, square.SquareColumn);
                Assert.Equal(squareStatus, square.SquareStatus);
                Assert.Null(square.Piece);
        }

        [Fact]
        public void Constructor_WhenPieceNotProvided_SquareStatusShouldBeUNOCCUPIED() {
            // Arrange
                char row = '1';
                char col = 'b';
                SquareStatus squareStatus = SquareStatus.UNOCCUPIED;
            // Act
                Square square = new Square(row, col, squareStatus);
            // Assert
                Assert.Null(square.Piece);
                Assert.True(square.SquareStatus == SquareStatus.UNOCCUPIED);
        }

        [Fact]
        public void Constructor_WhenPieceProvided_SquareStatusShouldBeOCCUPIED() {
            // Arrange
                char row = '1';
                char col = 'b';
                SquareStatus squareStatus = SquareStatus.OCCUPIED;
            // Act
                Square square = new Square(row, col, squareStatus);
            // Assert
                Assert.Null(square.Piece);
                Assert.True(square.SquareStatus == SquareStatus.OCCUPIED);
        }

        [Fact]
        public void GetSquareStatus_ShouldReturnSquareStatus() {
            // Arrange
                var sut = new Square('1', 'a', SquareStatus.OCCUPIED);
            // Act
                var result = sut.GetSquareStatus();
            // Assert
                Assert.Equal(SquareStatus.OCCUPIED, result);
        }

        [Fact]
        public void HasPiece_WhenPieceIsNotProvided_ShouldReturnFalse() {
            // Arrange
                var sut = new Square('1', 'a', SquareStatus.UNOCCUPIED);
            // Act
                var result = sut.HasPiece();
            // Assert
                Assert.False(result);
        }

        [Fact]
        public void HasPiece_WhenPieceIsProvided_ShouldReturnTrue() {
            // Arrange
                var piece = new King(PieceColor.WHITE);
                var sut = new Square('1', 'a', SquareStatus.OCCUPIED, piece);
            // Act
                var result = sut.HasPiece();
            // Assert
                Assert.True(result);
        }
    }
}