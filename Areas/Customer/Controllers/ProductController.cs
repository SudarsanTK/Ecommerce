using Ecommerce.Areas.Customer.Services;
using Ecommerce.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IOrderService _orderService;

        public ProductController(IProductService service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var products = _service.GetAllProducts();
            return View(products);
        }
        [HttpPost]
        public IActionResult Order(int productId, int quantity = 1)
        {
            var order = new OrderModel
            {
                ProductId = productId,
                Quantity = quantity,
                CustomerId = HttpContext.Session.GetInt32("CustomerId") ?? 0
            };

            _orderService.PlaceOrder(order);

            TempData["Message"] = "Order placed successfully!";
            return RedirectToAction("Index");
        }

    }
}
