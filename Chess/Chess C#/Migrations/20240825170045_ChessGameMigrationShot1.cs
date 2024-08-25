using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chess_C_.Migrations
{
    /// <inheritdoc />
    public partial class ChessGameMigrationShot1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ChessGame");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "ChessGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    Status = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.CheckConstraint("CK_GAME_STATUS", "Status IN ('ACTIVE', 'WHITE_WIN', 'BLACK_WIN', 'DRAW', 'RESIGN')");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "ChessGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    AccountStatus = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.CheckConstraint("CK_ACCOUNT_STATUS", "AccountStatus IN ('ACTIVE', 'BANNED', 'BLOCKED')");
                    table.CheckConstraint("CK_PLAYER_ZIPCODE", "LEN(ZipCode) = 5 OR LEN(ZipCode) = 9");
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                schema: "ChessGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    Status = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.CheckConstraint("CK_INVITATION_STATUS", "Status IN ('ACTIVE, ACCEPTED, CANCELLED')");
                    table.ForeignKey(
                        name: "FK_PLAYER_RECEIVE",
                        column: x => x.ReceiverId,
                        principalSchema: "ChessGame",
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PLAYER_SEND",
                        column: x => x.SenderId,
                        principalSchema: "ChessGame",
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                schema: "ChessGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromSquareRow = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    FromSquareColumn = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    ToSquareRow = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    ToSquareColumn = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    PieceType = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    PieceColor = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    KilledPieceType = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    IsCastling = table.Column<bool>(type: "BIT", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.CheckConstraint("CK_KILLED_PIECE_TYPE", "[KilledPieceType] IS NULL OR [KilledPieceType] IN ('PAWN', 'BISHOP', 'KNIGHT', 'ROOK', 'QUEEN', 'KING')");
                    table.CheckConstraint("CK_PIECE_COLOR", "PieceColor IN ('WHITE', 'BLACK')");
                    table.CheckConstraint("CK_PIECE_TYPE", "PieceType IN ('PAWN', 'BISHOP', 'KNIGHT', 'ROOK', 'QUEEN', 'KING')");
                    table.ForeignKey(
                        name: "FK_GAME_MOVE",
                        column: x => x.GameId,
                        principalSchema: "ChessGame",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLAYER_MOVE",
                        column: x => x.PlayerId,
                        principalSchema: "ChessGame",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                schema: "ChessGame",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GAME_PLAYER_GAME",
                        column: x => x.GameId,
                        principalSchema: "ChessGame",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLAYER_PLAYER_GAME",
                        column: x => x.PlayerId,
                        principalSchema: "ChessGame",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPhones",
                schema: "ChessGame",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPhones", x => new { x.PlayerId, x.Phone });
                    table.ForeignKey(
                        name: "FK_PlayerPhones_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "ChessGame",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_ReceiverId",
                schema: "ChessGame",
                table: "Invitations",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_SenderId",
                schema: "ChessGame",
                table: "Invitations",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameId",
                schema: "ChessGame",
                table: "Moves",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PlayerId",
                schema: "ChessGame",
                table: "Moves",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                schema: "ChessGame",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                schema: "ChessGame",
                table: "Players",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitations",
                schema: "ChessGame");

            migrationBuilder.DropTable(
                name: "Moves",
                schema: "ChessGame");

            migrationBuilder.DropTable(
                name: "PlayerGames",
                schema: "ChessGame");

            migrationBuilder.DropTable(
                name: "PlayerPhones",
                schema: "ChessGame");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "ChessGame");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "ChessGame");
        }
    }
}
