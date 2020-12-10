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
    public class DisciplinasController : Controller
    {
        private readonly ContextoSGATCC _context;

        public DisciplinasController(ContextoSGATCC context)
        {
            _context = context;
        }

        // GET: Disciplinas
        public async Task<IActionResult> Index()
        {
            var contextoSGATCC = _context.Disciplinas.ToListAsync();
            return View(await contextoSGATCC);
        }

        // GET: Disciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas

                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // GET: Disciplinas/Create
        public IActionResult Create()
        {
            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.lstCursos = listaCursos;
            return View();
        }

        // POST: Disciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarDisciplinaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Disciplinas.Add(new Disciplina
                {
                    CargaHoraria = viewModel.CargaHoraria,
                    Descricao = viewModel.Nome,
                    CursoId = viewModel.CursoId
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Disciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas.Include(x => x.Curso).FirstOrDefaultAsync(x => x.Id == id.Value);
            if (disciplina == null)
            {
                return NotFound();
            }

            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.lstCursos = listaCursos;
            return View(disciplina);
        }

        // POST: Disciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Disciplina disciplina)
        {
            if (id != disciplina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.Id))
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
            //ViewData["ProfessorId"] = new SelectList(_context.Professores, "ProfessorId", "ProfessorId", disciplina.ProfessorId);
            return View(disciplina);
        }

        // GET: Disciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplinas.Any(e => e.Id == id);
        }
    }
}
