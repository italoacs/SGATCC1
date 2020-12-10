using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class Adicionando_Relacionamento_na_tabela_alunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FrequenciaAlunos_AlunoDisciplinas_AlunoDisciplinaId",
                table: "FrequenciaAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaAlunos_AlunoDisciplinas_AlunoDisciplinaId",
                table: "NotaAlunos");

            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "DisciplinaCursos");

            migrationBuilder.DropIndex(
                name: "IX_NotaAlunos_AlunoDisciplinaId",
                table: "NotaAlunos");

            migrationBuilder.DropIndex(
                name: "IX_FrequenciaAlunos_AlunoDisciplinaId",
                table: "FrequenciaAlunos");

            migrationBuilder.DropColumn(
                name: "AlunoDisciplinaId",
                table: "NotaAlunos");

            migrationBuilder.DropColumn(
                name: "AlunoDisciplinaId",
                table: "FrequenciaAlunos");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Alunos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnoId",
                table: "Alunos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurnoId",
                table: "Alunos",
                column: "TurnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turnos_TurnoId",
                table: "Alunos",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "TurnoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turnos_TurnoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurnoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoDisciplinaId",
                table: "NotaAlunos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlunoDisciplinaId",
                table: "FrequenciaAlunos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    AlunoDisciplinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    TurmaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => x.AlunoDisciplinaId);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaCursos",
                columns: table => new
                {
                    DisciplinaCursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaCursos", x => x.DisciplinaCursoId);
                    table.ForeignKey(
                        name: "FK_DisciplinaCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaCursos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaAlunos_AlunoDisciplinaId",
                table: "NotaAlunos",
                column: "AlunoDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_FrequenciaAlunos_AlunoDisciplinaId",
                table: "FrequenciaAlunos",
                column: "AlunoDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_AlunoId",
                table: "AlunoDisciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaId",
                table: "AlunoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_TurmaId",
                table: "AlunoDisciplinas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaCursos_CursoId",
                table: "DisciplinaCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaCursos_DisciplinaId",
                table: "DisciplinaCursos",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FrequenciaAlunos_AlunoDisciplinas_AlunoDisciplinaId",
                table: "FrequenciaAlunos",
                column: "AlunoDisciplinaId",
                principalTable: "AlunoDisciplinas",
                principalColumn: "AlunoDisciplinaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaAlunos_AlunoDisciplinas_AlunoDisciplinaId",
                table: "NotaAlunos",
                column: "AlunoDisciplinaId",
                principalTable: "AlunoDisciplinas",
                principalColumn: "AlunoDisciplinaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
