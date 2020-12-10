using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGATCC.Areas.Coordenador.Models;
using SGATCC.Models;

namespace SGATCC.Contexto
{
    public class ContextoSGATCC : IdentityDbContext<IdentityUser>
    {
        public ContextoSGATCC(DbContextOptions<ContextoSGATCC> options)
            : base(options) { }


        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Turno>().HasData(
                new Turno { TurnoId = 1, Descricao = "Matutino", },
                new Turno { TurnoId = 2, Descricao = "Noturno", }
                );
        }
    }
}
