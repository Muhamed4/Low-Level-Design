using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;

namespace ChessC_UnitTest.PieceTest
{
    public class KnightTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Given
                PieceColor pieceColor = PieceColor.WHITE;
                PieceRank pieceRank = PieceRank.ONE;
            // When
                var sut = new Knight(pieceColor, pieceRank);
            // Then
                Assert.Equal(pieceColor, sut.GetPieceColor());
                Assert.Equal(PieceStatus.FIGHT, sut.GetPieceStatus());
                Assert.Equal(PieceType.KNIGHT, sut.GetPieceType());
                Assert.Equal(pieceRank, sut.GetRank());
        }

        [Theory]
        [InlineData(PieceStatus.FIGHT)]
        [InlineData(PieceStatus.KILLED)]
        public void SetPieceStatus_WhenPieceStatusIsSended_ShouldChangeThePropertyPieceStatus(PieceStatus pieceStatus) {
            // Arrange
                var sut = new Knight(PieceColor.WHITE, PieceRank.ONE);
            // Act
                sut.SetPieceStatus(pieceStatus);
            // Assert
                Assert.Equal(pieceStatus, sut.GetPieceStatus());
        }
    }
}