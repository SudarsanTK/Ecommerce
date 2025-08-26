using Ecommerce.Areas.Customer.Models;
using Ecommerce.Areas.Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public IActionResult Profile()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var customer = _service.GetById(customerId.Value);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Profile(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                _service.Update(customer);
                ViewBag.Message = "Profile updated successfully.";
            }
            return View(customer);
        }
    }
}
