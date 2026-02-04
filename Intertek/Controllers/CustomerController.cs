using Intertek.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intertek.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Customer/GetAllCustomersAsync")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Json(customers);
        }

        [HttpGet("Customer/GetTopSpendingCustomersAsync")]
        public async Task<IActionResult> GetTopSpendingCustomersAsync()
        {
            var spendingCustomers = await _customerService.GetTopSpendingCustomersAsync();
            return Json(spendingCustomers);
        }
    }
}
