using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGATCC.Areas.Coordenador.Controllers
{
    [Area("Coordenador")]
    [Authorize(Roles = "Coordenador,Professor")]
    public class RelatorioController : Controller
    {
        private readonly ContextoSGATCC _context;

        public RelatorioController(ContextoSGATCC context)
        {
            _context = context;
        }
        public IActionResult Grade()
        {
            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.Cursos = listaCursos;
            return View();
        }

        [HttpPost]
        public IActionResult BuscarAlunos(GradeFiltroViewModel viewModel)
        {
            var lstAlunos = _context.Alunos
                .Include(x => x.Curso)
                .Include(x => x.Turno).Where(x => x.CursoId == viewModel.CursoId).ToList();

            if (!string.IsNullOrEmpty(viewModel.Matricula))
                lstAlunos.FirstOrDefault(x => x.Matricula.ToLower().Contains(viewModel.Matricula.ToLower()));

            return PartialView("_lstAlunos", lstAlunos);
        }

        [HttpGet]
        public IActionResult PdfView(int alunoId, int cursoId)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == alunoId);
            var curso = _context.Cursos.Include(x => x.Disciplinas).FirstOrDefault(x => x.Id == cursoId);

            var pdf = new PdfViewModel();
            pdf.Nome = aluno.Nome;
            pdf.Matricula = aluno.Matricula;
            pdf.Curso = curso.Descricao;
            pdf.Data = DateTime.Now.ToString("dd/MM/yyyy");


            foreach (var item in curso.Disciplinas)
            {
                var aula = _context.Aulas.FirstOrDefault(y => y.DisciplinaId == item.Id && y.AlunoId == aluno.Id);
                var nota = _context.Notas.FirstOrDefault(y => y.DisciplinaId == item.Id && y.AlunoId == aluno.Id);

                if(aula != null && nota != null)
                {
                    int faltas = 0;
                    if (!aula.FreqAula1)
                        faltas++;

                    if (!aula.FreqAula2)
                        faltas++;

                    if (!aula.FreqAula3)
                        faltas++;

                    if (!aula.FreqAula4)
                        faltas++;

                    if (!aula.FreqAula5)
                        faltas++;

                    pdf.Materias.Add(new pdfMateriaViewModel
                    {
                        Disciplina = item.Descricao,
                        Faltas = faltas,
                        Nota = nota.ValorNota,
                        Situacao = nota.ValorNota >= 70 ? "Aprovado" : "Reprovado"

                    });
                }
            }
            return new ViewAsPdf("PdfView",pdf) { FileName = $"{pdf.Nome}.pdf"};
        }
    }
}
