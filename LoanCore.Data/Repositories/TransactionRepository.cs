using LoanCore.Data.Entities;

namespace LoanCore.Data.Repositories
{
    public class TransactionRepository
    {
        private readonly ApplicationDbContext _database;

        public TransactionRepository(ApplicationDbContext database)
        {
            _database = database;
        }

        public bool Add(Guid loanId, double amount, Guid typeId)
        {
            try
            {
                var transaction = new Transaction()
                {
                    LoanId = loanId,
                    Amount = amount,
                    TypeId = typeId,
                    CreatedAt = DateTime.UtcNow
                };

                _database.Transactions.Add(transaction);

                return _database.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}