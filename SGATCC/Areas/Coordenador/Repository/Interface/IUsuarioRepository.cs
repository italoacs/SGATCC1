using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SGATCC.Areas.Coordenador.Repository.Interface
{
    public interface IUsuarioRepository
    {
        string BuscarRole(string id);
        List<IdentityRole> ListarRoles();
    }
}
