using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using University.Data;
using University.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace University.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
           //var Name = HttpContext.Session.GetString("Name");
           // if (string.IsNullOrEmpty(Name))
           // {
           //     return RedirectToAction("Register", "Home");
           // }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        private readonly ApplicationDbContext _dbcontext;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel register)
        {

            if (ModelState.IsValid)
            {
                bool emailExists = _dbcontext.Accounts.Any(u => u.Email == register.Email);

                if (emailExists)
                {
                    ModelState.AddModelError("Email", "Email address already exists.");
                    return View(register);
                }
                _dbcontext.Accounts.Add(register);
                _dbcontext.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return View(register);
        }

       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {

            if (ModelState.IsValid)
            {
                var user = _dbcontext.Accounts.FirstOrDefault(account => account.Email == model.Email);

                if (user != null && user.Password == model.Password)
                {
                    HttpContext.Session.SetString("Name", user.firstName);
                   
                    HttpContext.Session.SetInt32("ID", user.Id);

                    if (model.Email == "adminunv@gmail.com")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Show", "Course");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            return View(model);
        }



        /*  public IActionResult Login(Login model)
          {
              if (ModelState.IsValid)
              {
                  var user = _dbcontext.Accounts.FirstOrDefault(account => account.Email == model.Email);
                  // HttpContext.Session.SetString("Name", user.firstName);
                  if (user != null && model.Email == "adminunv@gmail.com" && user.Password == model.Password)
                  {
                      HttpContext.Session.SetString("Name", user.firstName);
                      return RedirectToAction("Index", "Admin");
                  }
                  else if (user != null && user.Password == model.Password)
                  {
                      HttpContext.Session.SetString("Name", user.firstName);
                      return RedirectToAction("Index", "Course");
                  }
                  else if (user != null && user.Email != model.Email )
                  {
                      ModelState.AddModelError("", "Invalid email..!");
                  }
                  else
                  {
                      ModelState.AddModelError("", "Invalid email or password..!");
                  }
              }

              return View(model);
          }*/

    }
}
