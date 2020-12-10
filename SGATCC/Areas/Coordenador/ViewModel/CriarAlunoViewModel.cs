using System;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class CriarAlunoViewModel
    {
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Cpf obrigatório")]
        public string CPF { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Informe a Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Sexo obrigatório")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Telefone obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }
        public string Curso { get; set; }
        public string Turno { get; set; }
        public string Matricula { get; set; }
        public string Disciplina { get; set; }
    }
}
