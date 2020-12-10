using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class correcao_id_tabela_disciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Alunos_AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_AlunoId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Disciplinas");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Disciplinas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_AlunoId",
                table: "Disciplinas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Alunos_AlunoId",
                table: "Disciplinas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
