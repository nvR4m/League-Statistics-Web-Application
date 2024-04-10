using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rift.GG.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChampionMatchRelationship3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Champions_ChampionId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStats",
                table: "UserStats");

            migrationBuilder.DropIndex(
                name: "IX_UserStats_UserId",
                table: "UserStats");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ChampionId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_UserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StatId",
                table: "UserStats");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Matches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStats",
                table: "UserStats",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "UserMatches",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    UserMatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatches", x => new { x.UserId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_UserMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMatches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMatches_MatchId",
                table: "UserMatches",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStats",
                table: "UserStats");

            migrationBuilder.AddColumn<int>(
                name: "StatId",
                table: "UserStats",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ChampionId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStats",
                table: "UserStats",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStats_UserId",
                table: "UserStats",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ChampionId",
                table: "Matches",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_UserId",
                table: "Matches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Champions_ChampionId",
                table: "Matches",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "ChampionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserId",
                table: "Matches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
