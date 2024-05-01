using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanCore.Models
{
    public class CustomerViewModel
    {
        [DisplayName("Nombre (s)")]
        [Required(ErrorMessage = "Debes ingresar el nombre")]
        [MaxLength(128, ErrorMessage = "Debe ser de máximo {1} caracteres")]
        public string FirstName { get; set; }

        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "Debes ingresar los apellidos")]
        [MaxLength(128, ErrorMessage = "Debe ser de máximo {1} caracteres")]
        public string LastName { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Debes ingresar el teléfono")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Debe ser de máximo {1} caracteres")]
        public string PhoneNumber { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Debes ingresar la dirección")]
        [MaxLength(256, ErrorMessage = "Debe ser de máximo {1} caracteres")]
        public string Address { get; set; }
    }
}