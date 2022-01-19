using Microsoft.EntityFrameworkCore.Migrations;

namespace WP_Liga.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rezultat",
                table: "Utakmica");

            migrationBuilder.AddColumn<int>(
                name: "Rezultat1",
                table: "Utakmica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rezultat2",
                table: "Utakmica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LigaID",
                table: "Tim",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tim_LigaID",
                table: "Tim",
                column: "LigaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tim_Liga_LigaID",
                table: "Tim",
                column: "LigaID",
                principalTable: "Liga",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tim_Liga_LigaID",
                table: "Tim");

            migrationBuilder.DropIndex(
                name: "IX_Tim_LigaID",
                table: "Tim");

            migrationBuilder.DropColumn(
                name: "Rezultat1",
                table: "Utakmica");

            migrationBuilder.DropColumn(
                name: "Rezultat2",
                table: "Utakmica");

            migrationBuilder.DropColumn(
                name: "LigaID",
                table: "Tim");

            migrationBuilder.AddColumn<string>(
                name: "Rezultat",
                table: "Utakmica",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
