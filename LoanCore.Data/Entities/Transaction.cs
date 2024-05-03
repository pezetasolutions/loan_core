namespace LoanCore.Data.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid LoanId { get; set; }
        public Loan Loan { get; set; }
        public double Amount { get; set; }
        public Guid TypeId { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}