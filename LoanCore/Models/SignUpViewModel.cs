using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanCore.Models
{
    public class SignUpViewModel
    {
        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "Debes ingresar tu correo electrónico")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo electrónico válido")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Debes ingresar una contraseña")]
        public string Password { get; set; }

        [DisplayName("Nombre (s)")]
        [Required(ErrorMessage = "Debes ingresar tu nombre")]
        [MaxLength(128, ErrorMessage = "Debe ser de máximo {1} caracteres")]
        public string FirstName { get; set; }

        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "Debes ingresar tus apellidos")]
        [MaxLength(128, ErrorMessage = "Debe ser de máximo {1} caracteres")]
        public string LastName { get; set; }
    }
}