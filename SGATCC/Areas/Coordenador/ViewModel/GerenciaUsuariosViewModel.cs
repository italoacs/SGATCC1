using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class GerenciaUsuariosViewModel
    {
        public Filtro Filtro { get; set; }
        public List<IdentityUser> UsuarioAplicacao { get; set; }
    }

    public class Filtro
    {
        [Display(Name ="Nome de Usuario")]
        public string Nome { get; set; }
    }
}
