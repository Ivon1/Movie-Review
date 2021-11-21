using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_Review.Data.Migrations
{
    public partial class Update_Classes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Country_CountryId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_Film_Janre_JanreId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_Film_Producer_ProducerId",
                table: "Film");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JanreId",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Film",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Country_CountryId",
                table: "Film",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Janre_JanreId",
                table: "Film",
                column: "JanreId",
                principalTable: "Janre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Producer_ProducerId",
                table: "Film",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Country_CountryId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_Film_Janre_JanreId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_Film_Producer_ProducerId",
                table: "Film");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Film",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JanreId",
                table: "Film",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Film",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Country_CountryId",
                table: "Film",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Janre_JanreId",
                table: "Film",
                column: "JanreId",
                principalTable: "Janre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Producer_ProducerId",
                table: "Film",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
