using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class DepartmentController : Controller
    {

        private ApplicationDbContext db;
        private IWebHostEnvironment img;
        public DepartmentController(ApplicationDbContext db, IWebHostEnvironment img)
        {
            this.db = db;
            this.img = img;
        }

        public IActionResult Index(string search)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            var departments = db.departments.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                departments = departments.Where(s =>
                    (s.department_name ).Contains(search)
                ).ToList();
            }

            if (departments.Count == 0)
            {
                ViewBag.ErrorMessage = "No Departments found.";
            }

            return View(departments);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            return View(new Departments());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Departments departments, IFormFile img_file)
        {

            string path = Path.Combine(img.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName);// wwwroot/Img/mina22.jpeg
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    //  ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                    departments.department_Pic = img_file.FileName;
                }

            }
            else
            {
                departments.department_Pic = "1.jpeg"; // to save the default image path in database.
            }


            db.departments.Add(departments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            Departments std = db.departments.Where(x => x.id == id).FirstOrDefault();
            return View(std);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Departments std = db.departments.Where(x => x.id == id).FirstOrDefault();
            return View(std);

        }
        [HttpPost]
        public IActionResult Delete(Departments departments)
        {
            db.departments.Remove(departments);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            Departments std = db.departments.Where(x => x.id == id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Departments departments, IFormFile img_file)
        {
            string path = Path.Combine(img.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName);// wwwroot/Img/mina22.jpeg
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    //  ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                    departments.department_Pic = img_file.FileName;
                }

            }
            else
            {
                departments.department_Pic = "1.jpeg"; // to save the default image path in database.
            }


            db.departments.Update(departments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     




    }
}
