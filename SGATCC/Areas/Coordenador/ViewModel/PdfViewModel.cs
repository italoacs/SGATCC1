using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class PdfViewModel
    {
        public PdfViewModel()
        {
            Materias = new List<pdfMateriaViewModel>();
        }
        public string Nome { get; set; }
        [Display(Name="Matricula")]
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string Data { get; set; }
        public List<pdfMateriaViewModel> Materias { get; set; }
    }

    public class pdfMateriaViewModel
    {
        public string Disciplina { get; set; }
        public int Faltas { get; set; }
        public double Nota { get; set; }
        [Display(Name = "Situação")]
        public string Situacao { get; set; }

    }
}
