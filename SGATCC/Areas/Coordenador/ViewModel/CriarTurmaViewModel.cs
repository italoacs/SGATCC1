using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class CriarTurmaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome da Turma")]
        public string Nome { get; set; }

        [Display(Name="Curso")]
        [Required(ErrorMessage ="Selecione o Curso")]
        public string CursoId { get; set; }
        [Display(Name = "Turno")]
        [Required(ErrorMessage = "Selecione o Turno")]
        public string TurnoId { get; set; }
        [Display(Name = "Professor")]
        [Required(ErrorMessage = "Selecione o Professor")]
        public string ProfessorId { get; set; }
        [Display(Name = "Disciplina")]
        [Required(ErrorMessage = "Selecione a Disciplina")]
        public string DisciplinaId { get; set; }
    }
}
