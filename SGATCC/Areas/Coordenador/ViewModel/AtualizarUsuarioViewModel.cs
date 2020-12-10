using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class AtualizarUsuarioViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Nome de Usuário")]
        public string NomeDeUsuario { get; set; }

        public string Role { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string NovaSenha { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        public string ConfirmaNovaSenha { get; set; }
    }
}
