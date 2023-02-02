using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacinasCampanhas.Migrations
{
    public partial class criacaodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Vacinas_VacinaId",
                table: "Campanhas");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_VacinaId",
                table: "Campanhas");

            migrationBuilder.AlterColumn<int>(
                name: "VacinaId",
                table: "Vacinas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NomeDaCampanha",
                table: "Campanhas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_NomeDaCampanha",
                table: "Campanhas",
                column: "NomeDaCampanha",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinas_Campanhas_VacinaId",
                table: "Vacinas",
                column: "VacinaId",
                principalTable: "Campanhas",
                principalColumn: "CampanhaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinas_Campanhas_VacinaId",
                table: "Vacinas");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_NomeDaCampanha",
                table: "Campanhas");

            migrationBuilder.AlterColumn<int>(
                name: "VacinaId",
                table: "Vacinas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NomeDaCampanha",
                table: "Campanhas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_VacinaId",
                table: "Campanhas",
                column: "VacinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Vacinas_VacinaId",
                table: "Campanhas",
                column: "VacinaId",
                principalTable: "Vacinas",
                principalColumn: "VacinaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
