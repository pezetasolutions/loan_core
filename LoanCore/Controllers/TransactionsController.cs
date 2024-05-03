using LoanCore.Data.Repositories;
using LoanCore.Models;
using LoanCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanCore.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly LoanRepository _loanRepository;
        private readonly FlashMessageService _flashMessageService;

        public TransactionsController(LoanRepository loanRepository, FlashMessageService flashMessageService)
        {
            _loanRepository = loanRepository;
            _flashMessageService = flashMessageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddInterestPaymentToModifyDay(Guid loanId)
        {
            var loan = _loanRepository.Get(loanId);

            if (loan == null)
            {
                _flashMessageService.AddError("No se encontró el préstamo");
                return RedirectToAction("Index", "Loans");
            }

            var processedLoan = new LoanViewModel()
            {
                Id = loan.Id,
                Customer = new CustomerViewModel()
                {
                    Id = loan.Customer.Id,
                    FirstName = loan.Customer.FirstName,
                    LastName = loan.Customer.LastName
                },
                Total = loan.Total,
                MonthlyInterest = loan.MonthlyInterest,
                Status = loan.Status.Name,
                Transactions = loan.Transactions is not null ? loan.Transactions.Select(s => new TransactionViewModel()
                {
                    Id = s.Id,
                    Amount = s.Amount,
                    Type = s.Type.Name,
                    CreatedAt = s.CreatedAt
                }).ToList() : null,
                CreatedAt = loan.CreatedAt
            };

            var model = new AddInterestPaymentToModifyDayViewModel()
            {
                NewDay = 0,
                DailyInterest = (processedLoan.MonthlyInterest / 100) / 30 * processedLoan.TotalDebtWithOutInterest,
                Loan = processedLoan
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult CalculateInterest(Guid loanId, int newDay)
        {
            try
            {
                var loan = _loanRepository.Get(loanId);

                if(loan is null)
                {
                    return NotFound(new { Error = "No se encontró el préstamo" });
                }

                var processedLoan = new LoanViewModel()
                {
                    Id = loan.Id,
                    Customer = new CustomerViewModel()
                    {
                        Id = loan.Customer.Id,
                        FirstName = loan.Customer.FirstName,
                        LastName = loan.Customer.LastName
                    },
                    Total = loan.Total,
                    MonthlyInterest = loan.MonthlyInterest,
                    Status = loan.Status.Name,
                    Transactions = loan.Transactions is not null ? loan.Transactions.Select(s => new TransactionViewModel()
                    {
                        Id = s.Id,
                        Amount = s.Amount,
                        Type = s.Type.Name,
                        CreatedAt = s.CreatedAt
                    }).ToList() : null,
                    CreatedAt = loan.CreatedAt
                };

                if (processedLoan.Transactions is null || processedLoan.Transactions.Count == 0)
                {
                    var currentDay = processedLoan.CreatedAt.Day;

                    if (newDay < currentDay)
                    {
                        var nextPayDate = processedLoan.CreatedAt.AddMonths(1);
                        nextPayDate = new DateTime(nextPayDate.Year, nextPayDate.Month, newDay);

                        var diffDays = (nextPayDate - processedLoan.CreatedAt).Days;

                        var interestToPay = (processedLoan.MonthlyInterest / 100) / 30 * processedLoan.TotalDebtWithOutInterest * diffDays;

                        return Ok(new { InterestToPay = interestToPay, DiffDays = diffDays, NewDate = nextPayDate });
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
        }
    }
}