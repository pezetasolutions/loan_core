using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanCore.Data.Repositories
{
    public class LoanRepository
    {
        private readonly ApplicationDbContext _database;

        public LoanRepository(ApplicationDbContext database)
        {
            _database = database;
        }

        public List<Loan> GetAll()
        {
            try
            {
                return _database
                    .Loans
                    .Include(i => i.Customer)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Add(Guid customerId, int total, double monthlyInterest)
        {
            try
            {
                _database.Loans.Add(new Loan()
                {
                    CustomerId = customerId,
                    Total = total,
                    MonthlyInterest = monthlyInterest,
                    CreatedAt = DateTime.UtcNow
                });

                return _database.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var loan = _database.Loans.FirstOrDefault(f => f.Id == id);

                if (loan is null)
                {
                    return false;
                }

                _database.Loans.Remove(loan);

                return _database.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}