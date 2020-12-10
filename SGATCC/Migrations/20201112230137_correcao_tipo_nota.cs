using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class correcao_tipo_nota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorNota",
                table: "Notas",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValorNota",
                table: "Notas",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
