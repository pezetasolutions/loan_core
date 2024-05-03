using System.ComponentModel;

namespace LoanCore.Models
{
    public class AddInterestPaymentToModifyDayViewModel
    {
        public LoanViewModel Loan { get; set; }

        [DisplayName("Nuevo día")]
        public int NewDay { get; set; }

        public DateTime NewDate { get; set; }

        [DisplayName("Interés a pagar")]
        public double InterestToPay { get; set; }
        public double DailyInterest { get; set; }
    }
}