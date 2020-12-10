using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGATCC.Areas.Coordenador.Models;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGATCC.Areas.Coordenador.Controllers
{
    [Area("Coordenador")]
    [Authorize(Roles = "Coordenador,Professor")]
    public class LancamentosController : Controller
    {
        private readonly ContextoSGATCC _context;
        public LancamentosController(ContextoSGATCC context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.lstCursos = listaCursos;
            return View();
        }

        public JsonResult BuscarTurnosDoCurso([FromQuery] string cursoId)
        {
            var dados = _context.Turmas.Include(x => x.Turno).Where(x => x.CursoId == int.Parse(cursoId)).Distinct().ToList();

            var dadosFiltrados = new List<Turno>();

            dados.ForEach(x =>
            {
                var existe = dadosFiltrados.FirstOrDefault(y => y.TurnoId == x.Turno.TurnoId);

                if (existe == null)
                {
                    dadosFiltrados.Add(x.Turno);
                }

            });

            return Json(dadosFiltrados.Select(x => new
            {
                Id = x.TurnoId,
                Turno = x.Descricao
            }));
        }

        public async Task<JsonResult> BuscarDisciplinasDoCurso([FromQuery] string cursoId, [FromQuery] string turnoId)
        {
            var dados = await _context.Turmas.Include(x => x.Professor)
                .ThenInclude(y => y.Disciplina)
                .Where(x => x.CursoId == int.Parse(cursoId) && x.TurnoId == int.Parse(turnoId))
                .ToListAsync();

            return Json(dados.Select(x => new
            {
                Id = x.Professor.Disciplina.Id,
                Disciplina = x.Professor.Disciplina.Descricao,
            }));
        }

        [HttpPost]
        public IActionResult BuscarAlunos(FiltroNotasEChamadaViewModel viewModel)
        {
            var dadosAlunos = _context.Alunos.Where(x => x.CursoId == int.Parse(viewModel.Curso) && x.TurnoId == int.Parse(viewModel.Turno)).ToList();

            if (!string.IsNullOrEmpty(viewModel.NomeAluno))
                dadosAlunos = dadosAlunos.Where(x => x.Nome.ToLower().Contains(viewModel.NomeAluno.ToLower())).ToList();

            var dadosDisciplina = _context.Disciplinas.FirstOrDefault(x => x.Id == int.Parse(viewModel.Disciplina));

            var lstAlunos = dadosAlunos.Select(x => new CriarAlunoViewModel
            {
                AlunoId = x.Id,
                Matricula = x.Matricula,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                Disciplina = dadosDisciplina.Descricao
            }).ToList();

            return PartialView("_LstAlunos", lstAlunos);
        }

        [HttpGet]
        public async Task<IActionResult> Frequencia(string alunoId, string disciplina)
        {
            var disciplinaEntidade = await _context.Disciplinas
                .FirstOrDefaultAsync(x => x.Descricao.ToLower().Contains(disciplina.ToLower()));

            var aulaEntidade = await _context.Aulas
                .FirstOrDefaultAsync(x => x.AlunoId == int.Parse(alunoId) && x.DisciplinaId == disciplinaEntidade.Id);

            var aula = new AulaViewModel
            {
                DisciplinaId = disciplinaEntidade.Id,
                AlunoId = int.Parse(alunoId)
            };

            if (aulaEntidade != null)
            {
                aula.Aula1 = aulaEntidade.FreqAula1;
                aula.Aula2 = aulaEntidade.FreqAula2;
                aula.Aula3 = aulaEntidade.FreqAula3;
                aula.Aula4 = aulaEntidade.FreqAula4;
                aula.Aula5 = aulaEntidade.FreqAula5;
            }

            return PartialView("_Aula", aula);

        }

        [HttpGet]
        public async Task<IActionResult> Nota(string alunoId, string disciplina)
        {
            var disciplinaEntidade = await _context.Disciplinas
              .FirstOrDefaultAsync(x => x.Descricao.ToLower().Contains(disciplina.ToLower()));

            var notaEntidade = await _context.Notas
                .FirstOrDefaultAsync(x => x.AlunoId == int.Parse(alunoId) && x.DisciplinaId == disciplinaEntidade.Id);

            var nota = new Nota
            {
                AlunoId = int.Parse(alunoId),
                DisciplinaId = disciplinaEntidade.Id
            };

            if (notaEntidade != null)
            {
                nota.ValorNota = notaEntidade.ValorNota;
            }

            return PartialView("_Nota", nota);
        }

        [HttpPost]
        public IActionResult LancarNota(Nota viewModel)
        {
            var nota = _context.Notas.FirstOrDefault(x => x.AlunoId == viewModel.AlunoId && x.DisciplinaId == viewModel.DisciplinaId);

            try
            {
                if (nota is null)
                {
                    _context.Notas.Add(new Nota
                    {
                        DisciplinaId = viewModel.DisciplinaId,
                        AlunoId = viewModel.AlunoId,
                        ValorNota = viewModel.ValorNota,
                        Aprovado = viewModel.Aprovado
                    });
                }
                else
                {
                    nota.ValorNota = viewModel.ValorNota;
                    nota.Aprovado = viewModel.Aprovado;
                    _context.Notas.Update(nota);
                }

                _context.SaveChanges();
                return Json(new { Erro = false, Msg = "Nota Lançada" });
            }
            catch (Exception ex)
            {

                return Json(new { Erro = true, Msg = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult LancarFrequencia(AulaViewModel viewModel)
        {
            var aula = _context.Aulas.FirstOrDefault(x => x.AlunoId == viewModel.AlunoId && x.DisciplinaId == viewModel.DisciplinaId);

            try
            {
                if (aula is null)
                {
                    _context.Aulas.Add(new Aula
                    {
                        DisciplinaId = viewModel.DisciplinaId,
                        AlunoId = viewModel.AlunoId,
                        FreqAula1 = viewModel.Aula1,
                        FreqAula2 = viewModel.Aula2,
                        FreqAula3 = viewModel.Aula3,
                        FreqAula4 = viewModel.Aula4,
                        FreqAula5 = viewModel.Aula5,
                    });
                }
                else
                {
                    aula.FreqAula1 = viewModel.Aula1;
                    aula.FreqAula2 = viewModel.Aula2;
                    aula.FreqAula3 = viewModel.Aula3;
                    aula.FreqAula4 = viewModel.Aula4;
                    aula.FreqAula5 = viewModel.Aula5;
                    _context.Aulas.Update(aula);
                }

                _context.SaveChanges();
                return Json(new { Erro = false, Msg = "Frequencia Lancada" });
            }
            catch (Exception ex)
            {

                return Json(new { Erro = true, Msg = ex.Message });
            }
        }
    }
}
