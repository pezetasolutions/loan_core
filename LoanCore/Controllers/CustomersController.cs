using LoanCore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoanCore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _customersRepository;

        public CustomersController(CustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public IActionResult Index()
        {
            var customers = _customersRepository.GetAll();

            return View(customers);
        }
    }
}