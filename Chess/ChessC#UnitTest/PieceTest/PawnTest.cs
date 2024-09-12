using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;

namespace ChessC_UnitTest.PieceTest
{
    public class PawnTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Given
                PieceColor pieceColor = PieceColor.WHITE;
                PieceRank pieceRank = PieceRank.ONE;
            // When
                var sut = new Pawn(pieceColor, pieceRank);
            // Then
                Assert.Equal(pieceColor, sut.GetPieceColor());
                Assert.Equal(PieceStatus.FIGHT, sut.GetPieceStatus());
                Assert.Equal(PieceType.PAWN, sut.GetPieceType());
                Assert.Equal(pieceRank, sut.GetRank());
        }

        [Theory]
        [InlineData(PieceStatus.FIGHT)]
        [InlineData(PieceStatus.KILLED)]
        public void SetPieceStatus_WhenPieceStatusIsSended_ShouldChangeThePropertyPieceStatus(PieceStatus pieceStatus) {
            // Arrange
                var sut = new Pawn(PieceColor.WHITE, PieceRank.ONE);
            // Act
                sut.SetPieceStatus(pieceStatus);
            // Assert
                Assert.Equal(pieceStatus, sut.GetPieceStatus());
        }
    }
}