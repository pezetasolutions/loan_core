using LoanCore.Data.Repositories;
using LoanCore.Models;
using LoanCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanCore.Controllers
{
    public class LoansController : Controller
    {
        private readonly LoanRepository _loanRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly FlashMessageService _flashMessageService;

        public LoansController(LoanRepository loanRepository, FlashMessageService flashMessageService, CustomerRepository customerRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
            _flashMessageService = flashMessageService;
        }

        public IActionResult Index()
        {
            var loans = _loanRepository.GetAll();

            return View(loans.Select(s => new LoanViewModel()
            {
                Id = s.Id,
                Customer = new CustomerViewModel()
                {
                    Id = s.Id,
                    FirstName = s.Customer.FirstName,
                    LastName = s.Customer.LastName,
                    PhoneNumber = s.Customer.PhoneNumber,
                    Address = s.Customer.Address
                },
                Total = s.Total,
                Transactions = s.Transactions.Select(t => new TransactionViewModel()
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Type = t.Type.Name,
                    CreatedAt = t.CreatedAt
                }).ToList(),
                MonthlyInterest = s.MonthlyInterest,
                Status = GetStatusName(s.Status.Name),
                CreatedAt = s.CreatedAt
            }).ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddLoanViewModel();

            model.Customers = GetCustomers();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddLoanViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Customers = GetCustomers();
                    return View(model);
                }

                var added = _loanRepository.Add(model.CustomerId, model.Total, model.MonthlyInterest, model.CreatedAt);

                if (added)
                {
                    _flashMessageService.AddSuccess("Préstamo agregado correctamente");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al intentar agregar el préstamo");

                    model.Customers = GetCustomers();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                model.Customers = GetCustomers();
                return View(model);
            }
        }

        private string GetStatusName(string status)
        {
            return status switch
            {
                "Active" => "Activo",
                "Paid" => "Liquidado",
                "Late" => "Activo con retraso",
                _ => "Desconocido"
            };
        }

        private List<CustomerViewModel> GetCustomers()
        {
            var customers = _customerRepository.GetAll();

            return customers.Select(s => new CustomerViewModel()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address
            }).ToList();
        }
    }
}