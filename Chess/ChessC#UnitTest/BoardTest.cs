using System.ComponentModel;
using System.Reflection;
using Chess_C_.Models;

namespace ChessC_UnitTest;

public class BoardTest
{
    [Fact]
    public void InitializeWhitePieces_ShouldInitializeCorrectly()
    {
        // Arrange
            var sut = new Board();
            MethodInfo? privateMethod = typeof(Board).GetMethod("InitializeWhitePieces", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(privateMethod);
        // Act
            privateMethod.Invoke(sut, null);
            var WhitePiecesField = typeof(Board).GetField("WhitePieces", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(WhitePiecesField);
            var whitePieces = (List<Piece>)WhitePiecesField.GetValue(sut);
        // Assert
            Assert.NotNull(whitePieces);
            Assert.Equal(16, whitePieces.Count);
            Assert.Equal(8, whitePieces.Count(p => p is Pawn));
            Assert.Equal(2, whitePieces.Count(p => p is Bishop));
            Assert.Equal(2, whitePieces.Count(p => p is Knight));
            Assert.Equal(2, whitePieces.Count(p => p is Rook));
            Assert.Equal(1, whitePieces.Count(p => p is Queen));
            Assert.Equal(1, whitePieces.Count(p => p is King));
            Assert.True(whitePieces.All(p => p.GetPieceColor() == PieceColor.WHITE), "All Pieces should be white.");
    }


    [Fact]
    public void InitializeBlackPieces_ShouldInitializeCorrectly()
    {
        // Arrange
            var sut = new Board();
            MethodInfo? privateMethod = typeof(Board).GetMethod("InitializeBlackPieces", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(privateMethod);
        // Act
            privateMethod.Invoke(sut, null);
            var BlackPiecesField = typeof(Board).GetField("BlackPieces", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(BlackPiecesField);
            var blackPieces = (List<Piece>)BlackPiecesField.GetValue(sut);
        // Assert
            Assert.NotNull(blackPieces);
            Assert.Equal(16, blackPieces.Count);
            Assert.Equal(8, blackPieces.Count(p => p is Pawn));
            Assert.Equal(2, blackPieces.Count(p => p is Bishop));
            Assert.Equal(2, blackPieces.Count(p => p is Knight));
            Assert.Equal(2, blackPieces.Count(p => p is Rook));
            Assert.Equal(1, blackPieces.Count(p => p is Queen));
            Assert.Equal(1, blackPieces.Count(p => p is King));
            Assert.True(blackPieces.All(p => p.GetPieceColor() == PieceColor.BLACK), "All Pieces should be black.");
    }

    [Theory]
    [InlineData('0', 'a')]
    [InlineData('1', 'm')]
    [InlineData('0', 'n')]
    [InlineData('9', 'b')]
    // [InlineData('0', 'a')]
    public void GetSquare_WhenParametersDoesNotMatchTheRange_ShouldThrowArgumentOutOfRangeException(char row, char col)
    {
        // Arrange
            var sut = new Board();
        // Act
            // sut.GetSquare(row, col);
        // Act / Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetSquare(row, col));
    }

    [Theory]
    [InlineData('1', 'h')]
    [InlineData('8', 'a')]
    [InlineData('1', 'a')]
    [InlineData('8', 'h')]
    public void GetSquare_WhenParametersMatchTheRange_ShouldReturnSquare(char row, char col) {
        // Arrange
            var sut = new Board();
        // Act
            var result = sut.GetSquare(row, col);
            FieldInfo? fieldInfo = typeof(Board).GetField("Squares", BindingFlags.NonPublic | BindingFlags.Instance);
            Square[,] squares = (Square[,])fieldInfo.GetValue(sut);
            Assert.NotNull(squares);
            var expected = squares[row - '0', col - 'a' + 1]; 
        // Assert
            Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('0', 'a')]
    [InlineData('1', 'm')]
    [InlineData('0', 'n')]
    [InlineData('9', 'b')]
    public void GetPiece_WhenParameterDoesNotMatchTheRange_ShouldThrownArgumentOutOfRangeException(char row, char col) {
        // Arrange
            var sut = new Board();
        // Act / Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetPiece(row, col));
    }

    [Theory]
    [InlineData('1', 'a')]
    [InlineData('1', 'h')]
    [InlineData('8', 'a')]
    [InlineData('8', 'h')]
    public void GetPiece_WhenParameterMatchTheRange_ShouldReturnNullOrThePieceExistInThisPlace(char row, char col) {
        // Arrange
            var sut = new Board();
        // Act
            var result = sut.GetPiece(row, col);
            FieldInfo? fieldInfo = typeof(Board).GetField("Squares", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(fieldInfo);
            var squares = (Square[,])fieldInfo.GetValue(sut);
            var expected = squares[row - '0', col - 'a' + 1].Piece;
        // Assert
            Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(PieceColor.WHITE)]
    public void GetAllPieces_WhenColorIsWhite_ReturnAllTheWhitePiecesExistInBoard(PieceColor pieceColor) {
        // Arrange
            var sut = new Board();
        // Act
            var result = sut.GetAllPieces(pieceColor);
            FieldInfo? fieldInfo = typeof(Board).GetField("WhitePieces", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(fieldInfo);
            var expected = (List<Piece>)fieldInfo.GetValue(sut);
        // Assert
            Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(PieceColor.BLACK)]
    public void GetAllPieces_WhenColorIsBlack_ReturnAllTheBlackPiecesExistInBoard(PieceColor pieceColor) {
        // Arrange
            var sut = new Board();
        // Act
            var result = sut.GetAllPieces(pieceColor);
            FieldInfo? fieldInfo = typeof(Board).GetField("BlackPieces", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(fieldInfo);
            var expected = (List<Piece>)fieldInfo.GetValue(sut);
        // Assert
            Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData((PieceColor)(-1))]
    public void GetAllPieces_WhenThereIsNoColor_ThrowInvalidEnumArgumentException(PieceColor pieceColor) {
        // Arrange
            var sut = new Board();
        // Act / Assert
            Assert.Throws<InvalidEnumArgumentException>(() => sut.GetAllPieces(pieceColor));

    }
}