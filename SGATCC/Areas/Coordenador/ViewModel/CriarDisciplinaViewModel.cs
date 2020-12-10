using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class CriarDisciplinaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int CargaHoraria { get; set; }
        [Required]
        [Display(Name="Curso")]
        public int CursoId { get; set; }
    }
}
