using System.ComponentModel.DataAnnotations;

namespace SGATCC.Areas.Coordenador.ViewModel
{
    public class RegistrarViewModel
    {

        [Required(ErrorMessage = "Escolha o tipo de Usuário")]
        public string TipoUsuario { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        [MinLength(4, ErrorMessage = "O Usuário deve ter no mínimo 4 caracteres")]
        [MaxLength(20, ErrorMessage = "O Usuário deve ter no máximo 20 caracteres")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [MinLength(6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        [Display(Name = "Disciplina")]
        public string DisciplinaId { get; set; }
    }
}
