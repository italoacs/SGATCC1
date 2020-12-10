using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class AulaViewModel
    {
        public int DisciplinaId { get; set; }
        public int AlunoId { get; set; }
        [Display(Name ="Aula 1")]
        public bool Aula1 { get; set; }
        [Display(Name = "Aula 2")]
        public bool Aula2 { get; set; }
        [Display(Name = "Aula 3")]
        public bool Aula3 { get; set; }
        [Display(Name = "Aula 4")]
        public bool Aula4 { get; set; }
        [Display(Name = "Aula 5")]
        public bool Aula5 { get; set; }
    }
}
