using Microsoft.AspNetCore.Identity;
using SGATCC.Areas.Coordenador.Repository.Interface;
using SGATCC.Areas.Coordenador.Services.Interface;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace SGATCC.Areas.Coordenador.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(UserManager<IdentityUser> userManager, IUsuarioRepository usuarioRepository)
        {
            _userManager = userManager;
            _usuarioRepository = usuarioRepository;
        }

        public string BuscarRole(string id)
        {
            return _usuarioRepository.BuscarRole(id);
        }

        public List<IdentityRole> ListarRoles()
        {
            return _usuarioRepository.ListarRoles();
        }

        public List<IdentityUser> PesquisaUsuariosCadastrados(GerenciaUsuariosViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Filtro.Nome))
            {
                return _userManager.Users.Where(x => x.UserName.ToUpper().Contains(model.Filtro.Nome.ToUpper())).ToList();
            }

            return _userManager.Users.ToList();
        }

        public bool VerificaUsuarioCadastrado(string userName)
        {
            var usuario = _userManager.Users.Where(x => x.UserName == userName).ToList();

            if (usuario.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
