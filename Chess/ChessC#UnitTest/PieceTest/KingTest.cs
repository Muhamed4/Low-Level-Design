using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;

namespace ChessC_UnitTest.PieceTest
{
    public class KingTest
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Given
                PieceColor pieceColor = PieceColor.WHITE;
            // When
                var sut = new King(pieceColor);
            // Then
                Assert.Equal(pieceColor, sut.GetPieceColor());
                Assert.Equal(PieceStatus.FIGHT, sut.GetPieceStatus());
                Assert.Equal(PieceType.KING, sut.GetPieceType());
                Assert.Equal(PieceRank.ONE, sut.GetRank());
        }

        [Theory]
        [InlineData(PieceStatus.FIGHT)]
        [InlineData(PieceStatus.KILLED)]
        public void SetPieceStatus_WhenPieceStatusIsSended_ShouldChangeThePropertyPieceStatus(PieceStatus pieceStatus) {
            // Arrange
                var sut = new King(PieceColor.WHITE);
            // Act
                sut.SetPieceStatus(pieceStatus);
            // Assert
                Assert.Equal(pieceStatus, sut.GetPieceStatus());
        }
    }
}