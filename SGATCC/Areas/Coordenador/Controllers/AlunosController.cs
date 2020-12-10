using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGATCC.Areas.Coordenador.Models;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using SGATCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;



namespace SGATCC.Areas.Coordenador.Controllers
{
    [Area("Coordenador")]
    [Authorize(Roles = "Coordenador")]
    public class AlunosController : Controller
    {
        private readonly ContextoSGATCC _context;

        public AlunosController(ContextoSGATCC context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.Include(x => x.Curso).Include(x => x.Turno).ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.lstCursos = listaCursos;
            return View();
        }

        public async Task<JsonResult> BuscarTurnosDoCurso(string cursoId)
        {
            var dadosTurma = await _context.Turmas
                .Where(x => x.CursoId == int.Parse(cursoId))
                .Include(x => x.Turno)
                .ToListAsync();

            var listaTurnos = dadosTurma.Select(x => new SelectListItem { Text = x.Turno.Descricao, Value = x.Turno.TurnoId.ToString() });

            return Json(listaTurnos);
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarAlunoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = new Aluno
                {
                    Nome = viewModel.Nome,
                    Matricula = $"MAT{DateTime.Today.Year}{viewModel.Nome.Substring(0, 3).ToUpper()}{viewModel.CPF.Substring(0,3)}",
                    Cpf = viewModel.CPF,
                    DataNascimento = viewModel.DataNascimento,
                    Sexo = viewModel.Sexo,
                    Telefone = viewModel.Telefone,
                    Email = viewModel.Email,
                    CursoId = int.Parse(viewModel.Curso),
                    TurnoId = int.Parse(viewModel.Turno)
                };
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            var alunoViewModel = new CriarAlunoViewModel
            {
                AlunoId = aluno.Id,
                Nome = aluno.Nome,
                CPF = aluno.Cpf,
                DataNascimento = aluno.DataNascimento,
                Email = aluno.Email,
                Sexo = aluno.Sexo,
                Telefone = aluno.Telefone,
                Curso = aluno.CursoId.ToString(),
                Turno = aluno.TurnoId.ToString()
            };

            var dadosCursos = _context.Cursos.ToList();
            var listaCursos = new List<SelectListItem> { new SelectListItem { Text = "Selecione o Curso", Value = "" } };
            listaCursos.AddRange(dadosCursos.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            var dadosTurma = await _context.Turmas
                .Where(x => x.CursoId == int.Parse(alunoViewModel.Curso))
                .Include(x => x.Turno)
                .ToListAsync();

            var listaTurnos = new List<SelectListItem> { new SelectListItem { Text = "Selecione", Value = "" }};
            listaTurnos.AddRange(dadosTurma.Select(x => new SelectListItem { Text = x.Turno.Descricao, Value = x.Turno.TurnoId.ToString()}));
            ViewBag.lstCursos = listaCursos;
            ViewBag.lstTurno = listaTurnos;
            return View(alunoViewModel);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CriarAlunoViewModel viewModel)
        {
            if (id != viewModel.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
                    aluno.Nome = viewModel.Nome;
                    aluno.Cpf = viewModel.CPF;
                    aluno.DataNascimento = viewModel.DataNascimento;
                    aluno.Sexo = viewModel.Sexo;
                    aluno.Telefone = viewModel.Telefone;
                    aluno.Email = viewModel.Email;
                    aluno.CursoId = int.Parse(viewModel.Curso);
                    aluno.TurnoId = int.Parse(viewModel.Turno);

                    
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(viewModel.AlunoId))
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

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
