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

        public Loan Get(Guid id)
        {
            try
            {
                return _database
                    .Loans
                    .Include(i => i.Customer)
                    .Include(i => i.Status)
                    .FirstOrDefault(w => w.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Loan> GetAll()
        {
            try
            {
                return _database
                    .Loans
                    .Include(i => i.Customer)
                    .Include(i => i.Status)
                    .Include(i => i.Transactions)
                        .ThenInclude(i => i.Type)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Add(Guid customerId, double total, double monthlyInterest, DateTime createdAt)
        {
            try
            {
                _database.Loans.Add(new Loan()
                {
                    CustomerId = customerId,
                    Total = total,
                    MonthlyInterest = monthlyInterest,
                    StatusId = _database.LoanStatuses.FirstOrDefault(f => f.Name == "Active").Id,
                    CreatedAt = createdAt.ToUniversalTime()
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