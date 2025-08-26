using Microsoft.AspNetCore.Mvc;
using Ecommerce.Areas.Admin.Models;
using Ecommerce.Areas.Admin.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        private bool IsAdminLoggedIn()
        {
            return HttpContext.Session.GetString("AdminUsername") != null;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }
            var products = _repo.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel product)
        {
            if (!IsAdminLoggedIn())
                return Json(new { success = false, message = "Session expired. Please login again." });

            if (ModelState.IsValid)
            {
                int newId = _repo.Add(product);  

                if (newId > 0)
                {
                    return Json(new { success = true, message = "Product created successfully!", id = newId });
                }

                return Json(new { success = false, message = "Failed to create product." });
            }

            return Json(new { success = false, message = "Invalid form data." });
        }


        public IActionResult Edit(int id)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account", new { area = "Admin" });

            var product = _repo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductModel product)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account", new { area = "Admin" });

            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account", new { area = "Admin" });

            var product = _repo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsAdminLoggedIn())
                return RedirectToAction("Login", "Account", new { area = "Admin" });

            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}