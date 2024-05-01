using LoanCore.Data.Repositories;
using LoanCore.Models;
using LoanCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanCore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _customersRepository;
        private readonly FlashMessageService _flashMessageService;

        public CustomersController(CustomerRepository customersRepository, FlashMessageService flashMessageService)
        {
            _customersRepository = customersRepository;
            _flashMessageService = flashMessageService;
        }

        public IActionResult Index()
        {
            var customers = _customersRepository.GetAll();

            return View(customers.Select(s => new CustomerViewModel()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                LoansCount = s.Loans.Count
            }).ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CustomerViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View();
                }

                var added = _customersRepository.Add(model.FirstName, model.LastName, model.PhoneNumber, model.Address);

                if (added)
                {
                    _flashMessageService.AddSuccess("Cliente agregado correctamente");

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al intentar agregar el cliente");

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var deleted = _customersRepository.Delete(id);

                if (deleted)
                {
                    _flashMessageService.AddSuccess("Cliente eliminado correctamente");
                }
                else
                {
                    _flashMessageService.AddError("Ocurrió un error al intentar eliminar el cliente");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _flashMessageService.AddError(ex.Message);

                return RedirectToAction("Index");
            }
        }
    }
}