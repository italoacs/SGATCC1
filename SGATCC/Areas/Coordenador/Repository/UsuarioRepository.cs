using Microsoft.AspNetCore.Identity;
using SGATCC.Areas.Coordenador.Repository.Interface;
using SGATCC.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace SGATCC.Areas.Coordenador.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextoSGATCC _context;

        public UsuarioRepository(ContextoSGATCC context)
        {
            _context = context;
        }
        public string BuscarRole(string id)
        {
            var idRole = _context.UserRoles.FirstOrDefault(x => x.UserId == id).RoleId;

            var role = _context.Roles.FirstOrDefault(x => x.Id == idRole).Name;

            return role;
        }

        public List<IdentityRole> ListarRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
