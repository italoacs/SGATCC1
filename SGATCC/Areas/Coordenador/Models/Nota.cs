using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Nota
    {
        public int Id { get; set; }
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        [Display(Name = "Nota")]
        [Range(0.0,100)]
        public double ValorNota { get; set; }
        public bool Aprovado { get; set; }

    }
}
