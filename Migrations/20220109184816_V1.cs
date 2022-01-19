using Microsoft.EntityFrameworkCore.Migrations;

namespace WP_Liga.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Liga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tim",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Skor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tim", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Igrac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Godiste = table.Column<int>(type: "int", nullable: false),
                    Visina = table.Column<int>(type: "int", nullable: false),
                    TimID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Igrac_Tim_TimID",
                        column: x => x.TimID,
                        principalTable: "Tim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utakmica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tim1ID = table.Column<int>(type: "int", nullable: true),
                    Tim2ID = table.Column<int>(type: "int", nullable: true),
                    Rezultat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Utakmica_Tim_Tim1ID",
                        column: x => x.Tim1ID,
                        principalTable: "Tim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utakmica_Tim_Tim2ID",
                        column: x => x.Tim2ID,
                        principalTable: "Tim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igrac_TimID",
                table: "Igrac",
                column: "TimID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_Tim1ID",
                table: "Utakmica",
                column: "Tim1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_Tim2ID",
                table: "Utakmica",
                column: "Tim2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Igrac");

            migrationBuilder.DropTable(
                name: "Liga");

            migrationBuilder.DropTable(
                name: "Utakmica");

            migrationBuilder.DropTable(
                name: "Tim");
        }
    }
}
