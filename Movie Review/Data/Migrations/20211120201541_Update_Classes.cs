using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_Review.Data.Migrations
{
    public partial class Update_Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToPhoto",
                table: "Film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToPhoto",
                table: "Film");
        }
    }
}
