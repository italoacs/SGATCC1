using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        [Display(Name ="Nome do Professor")]
        public string Nome { get; set; }
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}