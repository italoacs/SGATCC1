using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGATCC.Areas.Coordenador.Models;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using SGATCC.Models;

namespace SGATCC.Areas.Coordenador.Controllers
{
    [Area("Coordenador")]
    [Authorize(Roles = "Coordenador")]
    public class TurmasController : Controller
    {
        private readonly ContextoSGATCC _context;

        public TurmasController(ContextoSGATCC context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var contextoSGATCC = _context.Turmas.Include(t => t.Curso).Include(t => t.Turno).Include(x => x.Professor);
            return View(await contextoSGATCC.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Curso)
                .Include(t => t.Turno)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosTurno = _context.Turnos.ToList();
            var listaTurnos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Turno", Value = "" } };
            listaTurnos.AddRange(dadosTurno.Select(x => new SelectListItem { Text = x.Descricao, Value = x.TurnoId.ToString() }));

            var dadosDiscplina = _context.Disciplinas.ToList();
            var listaDisciplina = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            listaDisciplina.AddRange(dadosDiscplina.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.lstCursos = listaCursos;
            ViewBag.Turnos = listaTurnos;
            ViewBag.Disciplina = listaDisciplina;
            return View();
        }

        public JsonResult BuscarProfessoresDoCurso(string disciplinaId)
        {
            return Json(_context.Professores.Where(x => x.DisciplinaId == int.Parse(disciplinaId)).ToList());
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarTurmaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Turmas.Add(new Turma
                {
                    Nome = viewModel.Nome,
                    CursoId = int.Parse(viewModel.CursoId),
                    TurnoId = int.Parse(viewModel.TurnoId),
                    ProfessorId = int.Parse(viewModel.ProfessorId)
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosTurno = _context.Turnos.ToList();
            var listaTurnos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Turno", Value = "" } };
            listaTurnos.AddRange(dadosTurno.Select(x => new SelectListItem { Text = x.Descricao, Value = x.TurnoId.ToString() }));

            var dadosDiscplina = _context.Disciplinas.ToList();
            var listaDisciplina = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            listaDisciplina.AddRange(dadosDiscplina.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.lstCursos = listaCursos;
            ViewBag.Turnos = listaTurnos;
            ViewBag.Disciplina = listaDisciplina;

            return View(viewModel);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.Include(x => x.Professor).FirstOrDefaultAsync(x => x.TurmaId == id.Value);
            if (turma == null)
            {
                return NotFound();
            }

            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosTurno = _context.Turnos.ToList();
            var listaTurnos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Turno", Value = "" } };
            listaTurnos.AddRange(dadosTurno.Select(x => new SelectListItem { Text = x.Descricao, Value = x.TurnoId.ToString() }));

            var dadosDiscplina = _context.Disciplinas.ToList();
            var listaDisciplina = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            listaDisciplina.AddRange(dadosDiscplina.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosProfessor = _context.Professores.Where(x => x.ProfessorId == turma.ProfessorId);
            var listProfessores = new List<SelectListItem> { new SelectListItem { Text = "Selecione", Value = "" } };
            listProfessores.AddRange(dadosProfessor.Select( x => new SelectListItem { Text = x.Nome, Value = x.ProfessorId.ToString()}));

            ViewBag.lstCursos = listaCursos;
            ViewBag.Turnos = listaTurnos;
            ViewBag.Disciplina = listaDisciplina;
            ViewBag.lstProfessores = listProfessores ;

            var model = new CriarTurmaViewModel
            {
                Id = turma.TurmaId,
                Nome = turma.Nome,
                CursoId = turma.CursoId.ToString(),
                TurnoId = turma.TurnoId.ToString(),
                DisciplinaId = turma.Professor.DisciplinaId.ToString(),
                ProfessorId = turma.ProfessorId.ToString()
            };
            return View(model);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CriarTurmaViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var turma = await _context.Turmas.FirstOrDefaultAsync(x => x.TurmaId == viewModel.Id);
                    turma.Nome = viewModel.Nome;
                    turma.CursoId = int.Parse(viewModel.CursoId);
                    turma.TurnoId = int.Parse(viewModel.TurnoId);
                    turma.ProfessorId = int.Parse(viewModel.ProfessorId);
                    _context.Turmas.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosTurno = _context.Turnos.ToList();
            var listaTurnos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Turno", Value = "" } };
            listaTurnos.AddRange(dadosTurno.Select(x => new SelectListItem { Text = x.Descricao, Value = x.TurnoId.ToString() }));

            var dadosDiscplina = _context.Disciplinas.ToList();
            var listaDisciplina = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            listaDisciplina.AddRange(dadosDiscplina.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosProfessor = _context.Professores.Where(x => x.ProfessorId == int.Parse(viewModel.ProfessorId));
            var listProfessores = new List<SelectListItem> { new SelectListItem { Text = "Selecione", Value = "" } };
            listProfessores.AddRange(dadosProfessor.Select(x => new SelectListItem { Text = x.Nome, Value = x.ProfessorId.ToString() }));

            ViewBag.lstCursos = listaCursos;
            ViewBag.Turnos = listaTurnos;
            ViewBag.Disciplina = listaDisciplina;
            ViewBag.lstProfessores = listProfessores;

            return View(viewModel);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Curso)
                .Include(t => t.Turno)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}
