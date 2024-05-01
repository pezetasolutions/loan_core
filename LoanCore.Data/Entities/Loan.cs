using Microsoft.EntityFrameworkCore;

namespace LoanCore.Data.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Total { get; set; }
        public double MonthlyInterest { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}