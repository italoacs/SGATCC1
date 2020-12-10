using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class correcao_id_tabela_disciplina2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Disciplinas_DisciplinaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_DisciplinaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DisciplinaId",
                table: "Alunos",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Disciplinas_DisciplinaId",
                table: "Alunos",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
