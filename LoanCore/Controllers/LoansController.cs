using LoanCore.Data.Repositories;
using LoanCore.Models;
using LoanCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanCore.Controllers
{
    public class LoansController : Controller
    {
        private readonly LoanRepository _loanRepository;
        private readonly FlashMessageService _flashMessageService;

        public LoansController(LoanRepository loanRepository, FlashMessageService flashMessageService)
        {
            _loanRepository = loanRepository;
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
                MonthlyInterest = s.MonthlyInterest,
                CreatedAt = s.CreatedAt
            }).ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(LoanViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var added = _loanRepository.Add(model.Customer.Id, model.Total, model.MonthlyInterest);

                if (added)
                {
                    _flashMessageService.AddSuccess("Préstamo agregado correctamente");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al intentar agregar el préstamo");

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(model);
            }
        }
    }
}