using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAPI.Migrations
{
    public partial class criacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_campanhas",
                columns: table => new
                {
                    campanha_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_da_campanha = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    data_de_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_de_termino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status_da_campanha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_campanhas", x => x.campanha_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_vacinas",
                columns: table => new
                {
                    vacina_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_da_vacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dica_da_vacina = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vacinas", x => x.vacina_id);
                    table.ForeignKey(
                        name: "FK_tb_vacinas_tb_campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "tb_campanhas",
                        principalColumn: "campanha_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_vacinas_CampanhaId",
                table: "tb_vacinas",
                column: "CampanhaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_vacinas");

            migrationBuilder.DropTable(
                name: "tb_campanhas");
        }
    }
}
