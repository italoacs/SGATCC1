using Microsoft.AspNetCore.Identity;
using SGATCC.Contexto;
using System.Linq;

namespace SGATCC.Service
{
    public class CriaRoles
    {
        private readonly ContextoSGATCC _bancoDeDados;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CriaRoles(ContextoSGATCC bancoDeDados, RoleManager<IdentityRole> roleManager)
        {
            _bancoDeDados = bancoDeDados;
            _roleManager = roleManager;
        }


        public async void AdicionaRoles()
        {
            if (_bancoDeDados.Roles.Any())
            {
                return;
            }
            var coordenador = new IdentityRole
            {
                Name = "Coordenador"
            };

            var professor = new IdentityRole
            {
                Name = "Professor"
            };

            await _roleManager.CreateAsync(coordenador);
            await _roleManager.CreateAsync(professor);
        }
    }
}
