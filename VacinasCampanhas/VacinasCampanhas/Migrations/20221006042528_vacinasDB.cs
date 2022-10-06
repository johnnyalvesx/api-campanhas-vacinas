using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacinasCampanhas.Migrations
{
    public partial class vacinasDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacinaId",
                table: "Vacinas",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vacinas",
                newName: "VacinaId");
        }
    }
}
