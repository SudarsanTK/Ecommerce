using Microsoft.AspNetCore.Mvc;
using Ecommerce.Areas.Admin.Models;
using Ecommerce.Areas.Admin.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAdminRepository _adminRepo;

        public AccountController(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _adminRepo.GetAdminByUsername(username);

            if (admin != null && admin.Password == password) 
            {
                HttpContext.Session.SetString("AdminUsername", admin.Username);

                return Json(new { success = true, redirectUrl = Url.Action("Dashboard", "Admin", new { area = "Admin" }) });
            }

            return Json(new { success = false, message = "Invalid username or password." });
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminUsername");
            return RedirectToAction("Login", new { area = "Admin" });
        }
    }
}