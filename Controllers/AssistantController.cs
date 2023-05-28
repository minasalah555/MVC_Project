using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class AssistantController : Controller
    {


        private ApplicationDbContext db;
        private IWebHostEnvironment img;
        public AssistantController(ApplicationDbContext db, IWebHostEnvironment img)
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
            var Assistants = db.Assistants.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                Assistants = Assistants.Where(s =>
                    (s.first_name + " " + s.last_name).Contains(search)
                ).ToList();
            }

            if (Assistants.Count == 0)
            {
                ViewBag.ErrorMessage = "No students found.";
            }

            return View(Assistants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            return View(new Assistant());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Assistant assistants, IFormFile img_file)
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
                    assistants.Assistant_Pic = img_file.FileName;
                }

            }
            else
            {
                assistants.Assistant_Pic = "1.jpeg"; // to save the default image path in database.
            }
             if (!db.departments.Any(d => d.id == assistants.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", assistants);
            }

            db.Assistants.Add(assistants);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Assistant std = db.Assistants.Where(x => x.assistant_id == id).FirstOrDefault();
            return View(std);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            Assistant std = db.Assistants.Where(x => x.assistant_id == id).FirstOrDefault();
            return View(std);

        }
        [HttpPost]
        public IActionResult Delete(Assistant assistants)
        {
            db.Assistants.Remove(assistants);
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
            Assistant std = db.Assistants.Where(x => x.assistant_id == id).FirstOrDefault();
            return View(std);

        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Assistant assistants, IFormFile img_file)
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
                    assistants.Assistant_Pic= img_file.FileName;
                }

            }
            else
            {
                assistants.Assistant_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == assistants.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", assistants);
            }

            db.Assistants.Update(assistants);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






    }
}
