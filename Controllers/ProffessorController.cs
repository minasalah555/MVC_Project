using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class ProffessorController : Controller
    {

        private ApplicationDbContext db;
        private IWebHostEnvironment img;
        public ProffessorController(ApplicationDbContext db, IWebHostEnvironment img)
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
            var proffessor = db.proffessor.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                proffessor = proffessor.Where(s =>
                    (s.first_name + " " + s.last_name).Contains(search)
                ).ToList();
            }

            if (proffessor.Count == 0)
            {
                ViewBag.ErrorMessage = "No students found.";
            }

            return View(proffessor);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            return View(new proffessor());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(proffessor proffessor, IFormFile img_file)
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
                    proffessor.doctor_Pic = img_file.FileName;
                }

            }
            else
            {
                proffessor.doctor_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == proffessor.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", proffessor);
            }

            db.proffessor.Add(proffessor);
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
            proffessor pro=db.proffessor.Where(x=>x.doctor_id==id).FirstOrDefault();
            return View(pro);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            proffessor pro = db.proffessor.Where(x => x.doctor_id == id).FirstOrDefault();
            return View(pro);

        }
        [HttpPost]
        public IActionResult Delete(proffessor proffessor)
        {
            db.proffessor.Remove(proffessor);
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

            proffessor pro = db.proffessor.Where(x => x.doctor_id == id).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(proffessor proffessor, IFormFile img_file)
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
                    proffessor.doctor_Pic = img_file.FileName;
                }

            }
            else
            {
                proffessor.doctor_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == proffessor.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", proffessor);
            }

            db.proffessor.Update(proffessor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         


    }
}
