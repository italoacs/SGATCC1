using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        [Display(Name ="Turno")]
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }
    }
}