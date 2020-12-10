using System;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class CriarProfessorViewModel
    {
        public int ProfessorId { get; set; }

        [Display(Name = "Nome do Professor")]
        public string Nome { get; set; }
        public string CPF { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Disciplina")]
        public string DisciplinaId { get; set; }
    }
}
