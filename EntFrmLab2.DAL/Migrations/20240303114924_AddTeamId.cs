using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntFrmLab2.DAL.Migrations
{
    public partial class AddTeamId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameLoss = table.Column<int>(type: "int", nullable: false),
                    GameWin = table.Column<int>(type: "int", nullable: false),
                    GameTie = table.Column<int>(type: "int", nullable: false),
                    ScoredGoals = table.Column<int>(type: "int", nullable: false),
                    MissedHeads = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team1Idid = table.Column<int>(type: "int", nullable: false),
                    Team2Idid = table.Column<int>(type: "int", nullable: false),
                    GoalsTeam1 = table.Column<int>(type: "int", nullable: false),
                    GoalsTeam2 = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team1Idid",
                        column: x => x.Team1Idid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team2Idid",
                        column: x => x.Team2Idid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1Idid",
                table: "Matches",
                column: "Team1Idid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2Idid",
                table: "Matches",
                column: "Team2Idid");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
