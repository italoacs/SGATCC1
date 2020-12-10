using Microsoft.AspNetCore.Identity;
using SGATCC.Contexto;
using System.Linq;

namespace SGATCC.Service
{
    public class CriaAdministrador
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ContextoSGATCC _bancoDeDados;

        public CriaAdministrador(UserManager<IdentityUser> userManager, ContextoSGATCC bancoDeDados)
        {
            _userManager = userManager;
            _bancoDeDados = bancoDeDados;
        }

        public async void CriaUsuarioAdmin()
        {
            if (_bancoDeDados.Users.Any())
            {
                return;
            }
            string senha = "Bsb@2005";
            var coordenador = new IdentityUser
            {
                UserName = "Coordenador"
            };

            var resultado = await _userManager.CreateAsync(coordenador, senha);

            if (resultado.Succeeded)
            {
                await _userManager.AddToRoleAsync(coordenador, "Coordenador");
            }
        }
    }
}
