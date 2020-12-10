using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class GradeFiltroViewModel
    {
        [Display(Name ="Curso")]
        public int CursoId { get; set; }
        public string Matricula { get; set; }
    }
}
