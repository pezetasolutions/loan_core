using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanCore.Models
{
    public class LoanViewModel
    {
        public Guid Id { get; set; }
        public CustomerViewModel Customer { get; set; }

        [DisplayName("Total")]
        [Required(ErrorMessage = "Debes ingresar el total")]
        public int Total { get; set; }

        [DisplayName("Interés mensual")]
        [Required(ErrorMessage = "Debes ingresar el interés mensual")]
        public double MonthlyInterest { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}