using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanCore.Models
{
    public class SignInViewModel
    {
        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "Debes ingresar tu correo electrónico")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Debes ingresar tu contraseña")]
        public string Password { get; set; }

        [DisplayName("Mantener sesión iniciada")]
        public bool RememberMe { get; set; }
    }
}