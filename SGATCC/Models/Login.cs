using System.ComponentModel.DataAnnotations;

namespace SGATCC.Models
{
    public class Login
    {

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

    }
}
