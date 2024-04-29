using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageStudent.Data.Migrations
{
    public partial class Upadatedatabasescore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Enrollments",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
