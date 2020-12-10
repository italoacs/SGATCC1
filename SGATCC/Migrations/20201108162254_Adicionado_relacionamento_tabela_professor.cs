using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class Adicionado_relacionamento_tabela_professor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Professores_ProfessorId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Disciplinas");

            migrationBuilder.RenameColumn(
                name: "DisciplinaId",
                table: "Disciplinas",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Turmas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Turmas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Professores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Professores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_DisciplinaId",
                table: "Professores",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "TurmaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Disciplinas_DisciplinaId",
                table: "Professores",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Disciplinas_DisciplinaId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Professores_DisciplinaId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Disciplinas",
                newName: "DisciplinaId");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Disciplinas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Professores_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
