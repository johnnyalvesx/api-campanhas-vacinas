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
                name: "Vacinas",
                columns: table => new
                {
                    VacinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaVacina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DicaDaVacina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.VacinaId);
                });

            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaCampanha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDaCampanha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.CampanhaId);
                    table.ForeignKey(
                        name: "FK_Campanhas_Vacinas_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacinas",
                        principalColumn: "VacinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_VacinaId",
                table: "Campanhas",
                column: "VacinaId");
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
