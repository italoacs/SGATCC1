using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public bool FreqAula1 { get; set; }
        public bool FreqAula2 { get; set; }
        public bool FreqAula3 { get; set; }
        public bool FreqAula4 { get; set; }
        public bool FreqAula5 { get; set; }
    }
}
