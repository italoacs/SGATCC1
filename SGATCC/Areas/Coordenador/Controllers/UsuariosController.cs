using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGATCC.Areas.Coordenador.Services.Interface;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SGATCC.Areas.Coordenador.Controllers
{
    [Area("Coordenador")]
    [Authorize(Roles = "Coordenador")]
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioService _usuarioService;
        private readonly ContextoSGATCC _context;

        public UsuariosController(UserManager<IdentityUser> userManager, IUsuarioService usuarioService, ContextoSGATCC context)
        {
            _userManager = userManager;
            _usuarioService = usuarioService;
            _context = context;
        }
        [HttpGet]
        public IActionResult GerenciarUsuarios()
        {
            var model = new GerenciaUsuariosViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegistrarViewModel registroViewModel)
        {
            //if(registroViewModel.TipoUsuario == "Professor" && string.IsNullOrEmpty(registroViewModel.DisciplinaId))
            //{
            //    return Json(new { Erro = true, Msg = "Informe a Disciplina", Alert = true });
            //}
            if (registroViewModel.Password.Length < 6)
            {
                return Json(new { Erro = true, Msg = "A senha deve ter pelo menos 6 caracteres", Alert = true });
            }

            if (registroViewModel.Password != registroViewModel.PasswordConfirm)
            {
                return Json(new { Erro = true, Msg = "Senhas não conferem" });
            }

            var verificaUsuario = _usuarioService.VerificaUsuarioCadastrado(registroViewModel.UserName);

            if (verificaUsuario)
            {
                return Json(new { Erro = true, Msg = "Usuário Já está Cadastrado" });
            }

            //Cria Usuário
            var user = new IdentityUser
            {
                UserName = registroViewModel.UserName,
            };

            //if (!string.IsNullOrEmpty(registroViewModel.DisciplinaId))
            //{
            //    user.DisciplinaId = int.Parse(registroViewModel.DisciplinaId);
            //}


            var result = await _userManager.CreateAsync(user, registroViewModel.Password);

            if (result.Succeeded)
            {
                if (registroViewModel.TipoUsuario == "Coordenador")
                {
                    await _userManager.AddToRoleAsync(user, "Coordenador");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Professor");
                }

                return Json(new { Erro = false, Msg = "Usuário Cadastrado com Sucesso!" });
            }
            else
            {
                return Json(new { Erro = true, Msg = result.Errors.FirstOrDefault() });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PesquisaUsuariosCadastrados(GerenciaUsuariosViewModel model)
        {
            var lstUsuarios = _usuarioService.PesquisaUsuariosCadastrados(model);

            if (lstUsuarios.Count() > 0)
            {
                return PartialView("_lstUsuarios", lstUsuarios);
            }

            return Json(new { Erro = true, Msg = "Usuário Não Existe!" });
        }

        public IActionResult CriarUsuario()
        {
            var dados = _usuarioService.ListarRoles();
            
            var lista = new List<SelectListItem> { new SelectListItem { Text = "Selecione o tipo de Usuario", Value = "" } };
            lista.AddRange(dados.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }));

            var disciplinas = _context.Disciplinas.ToList();

            var listaDisciplinas = new List<SelectListItem> { new SelectListItem { Text = "Selecione a Disciplina", Value = "" } };
            listaDisciplinas.AddRange(disciplinas.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }));

            ViewBag.Roles = lista;
            ViewBag.Disciplinas = listaDisciplinas;

            return PartialView("_CriarUsuario");
        }

        public IActionResult Excluir(string id)
        {
            var model = new ExcluirViewModel()
            {
                Id = id
            };
            return PartialView("_ExcluirUsuario", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            await _userManager.DeleteAsync(usuario);

            return Json(new { Erro = false, Msg = "Usuário Excluido com Sucesso!" });
        }

        public async Task<IActionResult> Editar(string id)
        {
            var dados = _usuarioService.ListarRoles();

            var lista = new List<SelectListItem> { new SelectListItem { Text = "Selecione o tipo de Usuario", Value = "" } };
            lista.AddRange(dados.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }));

            ViewBag.Roles = lista;

            var usuario = await _userManager.FindByIdAsync(id);
            var role = _usuarioService.BuscarRole(id);

            var model = new AtualizarUsuarioViewModel()
            {
                Id = usuario.Id,
                NomeDeUsuario = usuario.UserName,
                Role = role
            };

            return View("EditarUsuario", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(AtualizarUsuarioViewModel registroViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(registroViewModel.NovaSenha))
                {
                    if (registroViewModel.NovaSenha.Length < 6)
                    {
                        return Json(new { Erro = true, Msg = "A senha deve ter pelo menos 6 caracteres", Alert = true });
                    }

                    if (registroViewModel.NovaSenha != registroViewModel.ConfirmaNovaSenha)
                    {
                        return Json(new { Erro = true, Msg = "Senhas não conferem" });
                    }
                }

                var splitNomeUsuario = registroViewModel.NomeDeUsuario.Split(' ');

                if (splitNomeUsuario.Count() > 1)
                    return Json(new { Erro = true, Msg = "Nome de Usuario não pode conter espaços" });

                var user = await _userManager.FindByIdAsync(registroViewModel.Id);
                user.UserName = registroViewModel.NomeDeUsuario;
                user.SecurityStamp = Guid.NewGuid().ToString();

                await _userManager.UpdateAsync(user);

                //ATUALIZA SENHA

                if (!string.IsNullOrEmpty(registroViewModel.NovaSenha))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    await _userManager.ResetPasswordAsync(user, token, registroViewModel.NovaSenha);
                }

                //ATUALIZA ROLE

                var oldRole = _usuarioService.BuscarRole(registroViewModel.Id);

                var result = await _userManager.RemoveFromRoleAsync(user, oldRole);


                await _userManager.AddToRoleAsync(user, registroViewModel.Role);

                return Json(new { Erro = false, Msg = registroViewModel.NomeDeUsuario + " atualizado com sucesso!" });
            }
            catch (Exception ex)
            {

                return Json(new { Erro = true, Msg = ex });
            }
        }

    }

}

