using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageStudent.Data.Migrations
{
    public partial class UpdateDatabasewithcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
