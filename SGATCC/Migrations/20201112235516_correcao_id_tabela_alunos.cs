using Microsoft.EntityFrameworkCore.Migrations;

namespace SGATCC.Migrations
{
    public partial class correcao_id_tabela_alunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Alunos",
                newName: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alunos",
                newName: "AlunoId");
        }
    }
}
