using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
