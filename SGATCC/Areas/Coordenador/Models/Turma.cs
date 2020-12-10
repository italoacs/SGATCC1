using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }

        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        [ForeignKey("Turno")]
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

    }
}
