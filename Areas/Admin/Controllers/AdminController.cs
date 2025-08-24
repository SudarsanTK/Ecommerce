using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var admin = HttpContext.Session.GetString("AdminUsername");
            if (admin == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            ViewBag.Admin = admin;
            return View();
        }
    }
}
