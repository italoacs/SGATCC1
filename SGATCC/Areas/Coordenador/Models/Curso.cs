using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Display(Name ="Nome do Curso")]
        public string Descricao { get; set; }
        public int CargaHorariaTotal { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
