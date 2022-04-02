using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_Review.Data.Migrations
{
    public partial class maxLenghtMovieDescriptionchangedto400 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieDescription",
                table: "Film",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(230)",
                oldMaxLength: 230);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieDescription",
                table: "Film",
                type: "nvarchar(230)",
                maxLength: 230,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);
        }
    }
}
