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
    public class ProfessoresController : Controller
    {
        private readonly ContextoSGATCC _context;

        public ProfessoresController(ContextoSGATCC context)
        {
            _context = context;
        }

        // GET: Professores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professores.Include(x => x.Disciplina).ToListAsync());
        }

        // GET: Professores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            var dadosDisciplina = _context.Disciplinas.ToList();

            var lstDisciplina = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            lstDisciplina.AddRange(dadosDisciplina.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));
            ViewBag.lstDisciplinas = lstDisciplina;

            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarProfessorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Professores.Add(new Professor
                {
                    Nome = viewModel.Nome,
                    DataNascimento = viewModel.DataNascimento,
                    Sexo = viewModel.Sexo,
                    Cpf = viewModel.CPF,
                    Email = viewModel.Email,
                    Telefone = viewModel.Telefone,
                    DisciplinaId = int.Parse(viewModel.DisciplinaId)
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var professor = await _context.Professores.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            var dadosDisciplina = _context.Disciplinas.ToList();

            var lstDisciplina = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            lstDisciplina.AddRange(dadosDisciplina.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));
            ViewBag.lstDisciplinas = lstDisciplina;

            return View(new CriarProfessorViewModel
            {
                ProfessorId = professor.ProfessorId,
                Nome = professor.Nome,
                DataNascimento = professor.DataNascimento,
                CPF = professor.Cpf,
                DisciplinaId = professor.DisciplinaId.ToString(),
                Email = professor.Email,
                Sexo = professor.Sexo,
                Telefone = professor.Telefone
            });
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CriarProfessorViewModel viewModel)
        {
            if (id != viewModel.ProfessorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var professor = _context.Professores.FirstOrDefault(x => x.ProfessorId == viewModel.ProfessorId);
                    professor.Nome = viewModel.Nome;
                    professor.DataNascimento = viewModel.DataNascimento;
                    professor.Email = viewModel.Email;
                    professor.Telefone = viewModel.Telefone;
                    professor.Cpf = viewModel.CPF;
                    professor.DisciplinaId = int.Parse(viewModel.DisciplinaId);

                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(viewModel.ProfessorId))
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
            return View(viewModel);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.ProfessorId == id);
        }
    }
}
