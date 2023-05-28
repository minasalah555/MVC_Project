using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }


    }
}
