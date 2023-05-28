using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class StudentController : Controller
    {

        private ApplicationDbContext db;
        private IWebHostEnvironment img;
        public StudentController(ApplicationDbContext db, IWebHostEnvironment img)
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
            var students = db.students.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s =>
                    (s.first_name + " " + s.last_name).Contains(search)
                ).ToList();
            }

            if (students.Count == 0)
            {
                ViewBag.ErrorMessage = "No students found.";
            }

            return View(students);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            return View(new Student());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Student Students, IFormFile img_file)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }

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
                    Students.Student_Pic = img_file.FileName;
                }

            }
            else
            {
                Students.Student_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == Students.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", Students);
            }

            db.students.Add(Students);
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
            Student std = db.students.Where(x => x.student_id == id).FirstOrDefault();
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
            Student std = db.students.Where(x => x.student_id == id).FirstOrDefault(); 
            return View(std);

        }
        
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            var enrollmentsToDelete = db.student_course.Where(e => e.student_id == student.student_id).ToList();
            db.student_course.RemoveRange(enrollmentsToDelete);
            db.SaveChanges();

            db.students.Remove(student);
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
            Student std = db.students.Where(x => x.student_id == id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Student Students, IFormFile img_file)
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
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
                    Students.Student_Pic = img_file.FileName;
                }

            }
            else
            {
                Students.Student_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == Students.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Edit", Students);
            }

            db.students.Update(Students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult StudentHistory()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            int stID = (int)HttpContext.Session.GetInt32("ID");

            List<student_course> enList= (List<student_course>) db.student_course.Where(i=>i.student_id==stID).ToList();
            List<Course> Stcourses = new List<Course>();
            foreach (student_course e in enList)
            {
                Course c = db.Course.FirstOrDefault(i => i.course_id == e.course_id);
                Stcourses.Add(c);
            
            }
            return View(Stcourses);
        }


        public IActionResult LogOut()
        {
          HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("Name");
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Login", "Home");
        }


    }
}
