using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntFrmLab2.DAL.Migrations
{
    public partial class ICollectionToList1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalScorer_Matches_MatchId",
                table: "GoalScorer");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalScorer_Players_PlayerId",
                table: "GoalScorer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoalScorer",
                table: "GoalScorer");

            migrationBuilder.RenameTable(
                name: "GoalScorer",
                newName: "GoalScorers");

            migrationBuilder.RenameIndex(
                name: "IX_GoalScorer_PlayerId",
                table: "GoalScorers",
                newName: "IX_GoalScorers_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GoalScorer_MatchId",
                table: "GoalScorers",
                newName: "IX_GoalScorers_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoalScorers",
                table: "GoalScorers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalScorers_Matches_MatchId",
                table: "GoalScorers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalScorers_Players_PlayerId",
                table: "GoalScorers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoalScorers_Matches_MatchId",
                table: "GoalScorers");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalScorers_Players_PlayerId",
                table: "GoalScorers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoalScorers",
                table: "GoalScorers");

            migrationBuilder.RenameTable(
                name: "GoalScorers",
                newName: "GoalScorer");

            migrationBuilder.RenameIndex(
                name: "IX_GoalScorers_PlayerId",
                table: "GoalScorer",
                newName: "IX_GoalScorer_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GoalScorers_MatchId",
                table: "GoalScorer",
                newName: "IX_GoalScorer_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoalScorer",
                table: "GoalScorer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoalScorer_Matches_MatchId",
                table: "GoalScorer",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalScorer_Players_PlayerId",
                table: "GoalScorer",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
