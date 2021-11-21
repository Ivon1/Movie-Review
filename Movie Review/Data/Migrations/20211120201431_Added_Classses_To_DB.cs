using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_Review.Data.Migrations
{
    public partial class Added_Classses_To_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Janre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JanreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Janre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FimlTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    JanreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Janre_JanreId",
                        column: x => x.JanreId,
                        principalTable: "Janre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_CountryId",
                table: "Film",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_JanreId",
                table: "Film",
                column: "JanreId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ProducerId",
                table: "Film",
                column: "ProducerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Janre");

            migrationBuilder.DropTable(
                name: "Producer");
        }
    }
}
