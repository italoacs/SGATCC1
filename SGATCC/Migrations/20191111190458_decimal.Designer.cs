﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGATCC.Contexto;

namespace SGATCC.Migrations
{
    [DbContext(typeof(ContextoSGATCC))]
    [Migration("20191111190458_decimal")]
    partial class @decimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Sexo");

                    b.Property<string>("Telefone");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoDisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId");

                    b.Property<int>("DisciplinaId");

                    b.Property<int>("TurmaId");

                    b.HasKey("AlunoDisciplinaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("AlunoDisciplinas");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargaHorariaTotal");

                    b.Property<string>("Descricao");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargaHoraria");

                    b.Property<string>("Descricao");

                    b.Property<int>("ProfessorId");

                    b.HasKey("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.DisciplinaCurso", b =>
                {
                    b.Property<int>("DisciplinaCursoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<int>("DisciplinaId");

                    b.HasKey("DisciplinaCursoId");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("DisciplinaCursos");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.FrequenciaAluno", b =>
                {
                    b.Property<int>("FrequenciaAlunoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoDisciplinaId");

                    b.Property<DateTime>("DataFrequencia");

                    b.Property<int>("Frequencia");

                    b.HasKey("FrequenciaAlunoId");

                    b.HasIndex("AlunoDisciplinaId");

                    b.ToTable("FrequenciaAlunos");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.NotaAluno", b =>
                {
                    b.Property<int>("NotaAlunoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoDisciplinaId");

                    b.Property<DateTime>("DataNota");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NotaAlunoId");

                    b.HasIndex("AlunoDisciplinaId");

                    b.ToTable("NotaAlunos");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Sexo");

                    b.Property<string>("Telefone");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Relatorio", b =>
                {
                    b.Property<int>("RelatorioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UsuarioId");

                    b.HasKey("RelatorioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<string>("Nome");

                    b.Property<int>("TurnoId");

                    b.HasKey("TurmaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("TurnoId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("TurnoId");

                    b.ToTable("Turnos");

                    b.HasData(
                        new
                        {
                            TurnoId = 1,
                            Descricao = "Matutino"
                        },
                        new
                        {
                            TurnoId = 2,
                            Descricao = "Noturno"
                        });
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.Aluno", "Aluno")
                        .WithMany("Disciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGATCC.Areas.Coordenador.Models.Disciplina", "Disciplina")
                        .WithMany("Alunos")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGATCC.Areas.Coordenador.Models.Turma", "Turma")
                        .WithMany("AlunoDisciplinas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Disciplina", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.DisciplinaCurso", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGATCC.Areas.Coordenador.Models.Disciplina", "Disciplina")
                        .WithMany("Cursos")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.FrequenciaAluno", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.AlunoDisciplina", "AlunoDisciplina")
                        .WithMany("FrequenciaAlunos")
                        .HasForeignKey("AlunoDisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.NotaAluno", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.AlunoDisciplina", "AlunoDisciplina")
                        .WithMany("NotaAluno")
                        .HasForeignKey("AlunoDisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Relatorio", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SGATCC.Areas.Coordenador.Models.Turma", b =>
                {
                    b.HasOne("SGATCC.Areas.Coordenador.Models.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SGATCC.Areas.Coordenador.Models.Turno", "Turno")
                        .WithMany("Turmas")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
