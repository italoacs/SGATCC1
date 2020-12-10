using Microsoft.AspNetCore.Identity;
using SGATCC.Areas.Coordenador.ViewModel;
using SGATCC.Contexto;
using System.Collections.Generic;

namespace SGATCC.Areas.Coordenador.Services.Interface
{
    public interface IUsuarioService
    {
        List<IdentityUser> PesquisaUsuariosCadastrados(GerenciaUsuariosViewModel model);
        bool VerificaUsuarioCadastrado(string userName);
        string BuscarRole(string id);
        List<IdentityRole> ListarRoles();
    }
}
