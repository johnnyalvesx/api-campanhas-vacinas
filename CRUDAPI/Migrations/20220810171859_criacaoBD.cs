using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAPI.Migrations
{
    public partial class criacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    VacinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.VacinaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacinas");
        }
    }
}
