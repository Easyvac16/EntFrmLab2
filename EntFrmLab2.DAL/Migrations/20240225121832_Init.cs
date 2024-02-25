using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntFrmLab2.DAL.Migrations
{
    public partial class Init : Migration
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
                    GameTie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
