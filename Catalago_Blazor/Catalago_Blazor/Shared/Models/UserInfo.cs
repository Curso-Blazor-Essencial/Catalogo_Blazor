using System.ComponentModel.DataAnnotations;

namespace Catalago_Blazor.Shared.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "Informe o email")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }

    }
}
