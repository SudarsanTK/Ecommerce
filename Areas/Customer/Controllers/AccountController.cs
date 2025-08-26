using Ecommerce.Areas.Customer.Models;
using Ecommerce.Areas.Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly ICustomerService _service;

        public AccountController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                _service.Register(customer);
                return RedirectToAction("Login");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var customer = _service.Login(email, password);
            if (customer != null)
            {
                HttpContext.Session.SetString("CustomerEmail", customer.Email);
                HttpContext.Session.SetInt32("CustomerId", customer.Id);

               return RedirectToAction("Index", "Product", new { area = "Customer" });

            }

            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
