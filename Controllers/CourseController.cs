using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using University;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class CourseController : Controller
    {

        private ApplicationDbContext db;
        private IWebHostEnvironment img;
        public CourseController(ApplicationDbContext db, IWebHostEnvironment img)
        {
            this.db = db;
            this.img = img;
        }
        public IActionResult Index(string search)
        {
            var Course = db.Course.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                Course = Course.Where(s =>
                    (s.course_name).Contains(search)
                ).ToList();
            }

            if (Course.Count == 0)
            {
                ViewBag.ErrorMessage = "No students found.";
            }

            return View(Course);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Course());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Course Courses, IFormFile img_file)
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
                    Courses.Course_Pic = img_file.FileName;
                }

            }
            else
            {
                Courses.Course_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == Courses.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", Courses);
            }

            db.Course.Add(Courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Details(int id)
        {
            Course std = db.Course.Where(x => x.course_id == id).FirstOrDefault();
            return View(std);

        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course std = db.Course.Where(x => x.course_id == id).FirstOrDefault();
            return View(std);

        }
        [HttpPost]
        public IActionResult Delete(Course Courses)
        {
            db.Course.Remove(Courses);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course std = db.Course.Where(x => x.course_id == id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Course Courses, IFormFile img_file)
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
                    Courses.Course_Pic = img_file.FileName;
                }

            }
            else
            {
                Courses.Course_Pic = "1.jpeg"; // to save the default image path in database.
            }
            if (!db.departments.Any(d => d.id == Courses.department_id))
            {
                ModelState.AddModelError("department_id", "The department ID entered does not exist.");
                return View("Create", Courses);
            }

            db.Course.Update(Courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Show()
        {
            var Name = HttpContext.Session.GetString("Name");

            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
           // HttpContext.Session.SetString("Name", user.firstName);

            
            List<Course> courses = db.Course.ToList();

            return View(courses);

        }


        public IActionResult AddToCart(int id)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem Item1 = cart.FirstOrDefault(i => i.course_id == id);
            if (Item1 != null)
            {

            }
            else
            {
                Course c1 = db.Course.FirstOrDefault(i => i.course_id == id);
                CartItem NewItem = new CartItem
                {
                    course_id = c1.course_id,
                    course_name = c1.course_name,
                    creditHour = c1.course_credits,


                };
                cart.Add(NewItem);
            }
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("Show", "Course");

        }

        public IActionResult Cart()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Register", "Home");
            }
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();

            return View(cart);

        }

        public IActionResult RemoveFromCart(int id)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem CItem = cart.Find(i => i.course_id == id);
            cart.Remove(CItem);
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("Cart");

        }

        public IActionResult CheckOut()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            int stID = (int)HttpContext.Session.GetInt32("ID");

            foreach (CartItem item in cart)
            {
                var existingEnrollment = db.student_course
                    .FirstOrDefault(e => e.student_id == stID && e.course_id == item.course_id);

                if (existingEnrollment == null)
                {
                    var enrollment = new student_course
                    {
                        student_id = stID,
                        course_id = item.course_id,
                    };

                    db.student_course.Add(enrollment);
                }
            }

            db.SaveChanges();
            HttpContext.Session.Remove("cart");

            return RedirectToAction("Show");
        }




        //public IActionResult CheckOut()
        //{

        //    List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
        //    int stID = (int)HttpContext.Session.GetInt32("ID");
        //    foreach (CartItem item in cart) 
        //    {
        //        var Enrol = new student_course
        //        {
        //            student_id = stID,
        //            course_id = item.course_id,
        //        };

        //        db.student_course.Add(Enrol);
        //        db.SaveChanges();
        //    }
        //    HttpContext.Session.Remove("cart");

        //    return RedirectToAction("Show");
        //}

    }
}