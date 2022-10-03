using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAPI.Migrations
{
    public partial class criacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_vacinas",
                columns: table => new
                {
                    pk_vacina_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_da_vacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dica_da_vacina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vacinas", x => x.pk_vacina_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_campanhas",
                columns: table => new
                {
                    pk_campanha_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_da_campanha = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    data_de_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_de_termino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status_da_campanha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fk_vacina_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_campanhas", x => x.pk_campanha_id);
                    table.ForeignKey(
                        name: "FK_tb_campanhas_tb_vacinas_fk_vacina_id",
                        column: x => x.fk_vacina_id,
                        principalTable: "tb_vacinas",
                        principalColumn: "pk_vacina_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_campanhas_fk_vacina_id",
                table: "tb_campanhas",
                column: "fk_vacina_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_campanhas");

            migrationBuilder.DropTable(
                name: "tb_vacinas");
        }
    }
}
