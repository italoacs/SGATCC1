using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class FiltroNotasEChamadaViewModel
    {
        public string Curso { get; set; }
        public string Turno { get; set; }
        public string Disciplina { get; set; }

        [Display(Name ="Nome do Aluno")]
        public string NomeAluno { get; set; }
    }
}
