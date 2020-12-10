using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class Inclusao_de_matricula_tabela_aluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Alunos",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Alunos");
        }
    }
}
