using System.ComponentModel.DataAnnotations;

namespace LoanCore.Models
{
    public class AddLoanViewModel
    {
        public Guid Id { get; set; }
        public List<CustomerViewModel> Customers { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Debes seleccionar un cliente")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Debes ingresar el total")]
        [Range(100, double.MaxValue, ErrorMessage = "El total debe ser mayor a $100")]
        public double Total { get; set; }

        [Display(Name = "Interés mensual")]
        [Required(ErrorMessage = "Debes ingresar el interés")]
        public double MonthlyInterest { get; set; }

        public string Status { get; set; }

        [Display(Name = "Fecha de préstamo")]
        [Required(ErrorMessage = "Debes ingresar la fecha de préstamo")]
        public DateTime CreatedAt { get; set; }
    }
}