namespace LoanCore.Models
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}