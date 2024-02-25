using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntFrmLab2.DAL.Migrations
{
    public partial class Add2Rows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MissedHeads",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoredGoals",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissedHeads",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ScoredGoals",
                table: "Teams");
        }
    }
}
