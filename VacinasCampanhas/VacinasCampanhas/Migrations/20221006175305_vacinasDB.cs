using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacinasCampanhas.Migrations
{
    public partial class vacinasDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaCampanha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusDaCampanha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.CampanhaId);
                });

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DicaDaVacina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Vacinas");
        }
    }
}
