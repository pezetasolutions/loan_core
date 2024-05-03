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
        public double Total { get; set; }
        public double TotalDebtWithOutInterest => GetTotalDebt();
        public double TotalDebt => GetTotalDebt() + GetInterestToPay();

        [DisplayName("Interés mensual")]
        [Required(ErrorMessage = "Debes ingresar el interés mensual")]
        public double MonthlyInterest { get; set; }
        public string Status { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ExpiredDays => GetExpiredDays();
        public double InterestToPay => GetInterestToPay();
        public DateTime? NextPay => GetNextPay();

        private DateTime? GetNextPay()
        {
            int payDay = CreatedAt.Day;

            if (Status == "Liquidado")
            {
                return null;
            }

            if (Transactions is null || Transactions.Count == 0)
            {
                return DateTime.Now.AddDays(30);
            }

            var lastPay = Transactions.LastOrDefault(f => f.Type == "Interest" || f.Type == "PartialPay");

            if (lastPay is null)
            {
                return CreatedAt.AddDays(ExpiredDays + 30);
            }

            return lastPay.CreatedAt.AddDays(ExpiredDays + 30);
        }

        private double GetTotalDebt()
        {
            double partialPays = 0;
            if (Transactions is not null)
            {
                partialPays = Transactions
                    .Where(f => f.Type == "PartialPay")
                    .Sum(f => f.Amount);
            }

            // Calcula la deuda total sin incluir interés
            return Total - partialPays;
        }


        private int GetExpiredDays()
        {
            if(Status == "Liquidado")
            {
                return 0;
            }

            if(Transactions is null || Transactions.Count == 0)
            {
                return (DateTime.UtcNow - CreatedAt).Days;
            }

            var lastPay = Transactions.LastOrDefault(f => f.Type == "Interest" || f.Type == "PartialPay");

            if (lastPay is null)
            {
                return (DateTime.UtcNow - CreatedAt).Days;
            }

            return (DateTime.UtcNow - lastPay.CreatedAt).Days;
        }

        private double GetInterestToPay()
        {
            double currentDebt = GetTotalDebt();  // Obtener la deuda actual sin interés
            return (currentDebt / 30 * MonthlyInterest / 100) * ExpiredDays;
        }
    }
}