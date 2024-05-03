namespace LoanCore.Data.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double Total { get; set; }
        public double MonthlyInterest { get; set; }
        public Guid StatusId { get; set; }
        public LoanStatus Status { get; set; }
        public HashSet<Transaction> Transactions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}