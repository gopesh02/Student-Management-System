using DataAcccessLayer;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using StudentManagementSystem.Models;
using System.Diagnostics;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var a = _db.StudentModels.ToList();

            @List<StudentModel> list = new List<StudentModel>();
            foreach (var i in a)
            {
                list.Add(new StudentModel()
                {
                    Student_ID = i.Student_ID,
                    FullName = i.FullName,
                    Phone = i.Phone,
                    Gender = i.Gender,
                    Email = i.Email,
                    Address = i.Address,
                    PinCode = i.PinCode
                });
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel demp)
        {
            StudentModel emp = new StudentModel();
            emp.Student_ID = demp.Student_ID;
            emp.FullName = demp.FullName;
            emp.Phone = demp.Phone;
            emp.Gender = demp.Gender;
            emp.Email = demp.Email;
            emp.Address = demp.Address;
            emp.PinCode = demp.PinCode;

            if (emp.Student_ID == 0)
            {
                _db.StudentModels.Add(emp);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       
//        [HttpGet]
//        public IActionResult Edit()
//        {
//            return View();
//;        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var a = _db.StudentModels.Where(m => m.Student_ID == id).FirstOrDefault();
            StudentModel emp = new StudentModel();
            emp.Student_ID = a.Student_ID;
            emp.FullName = a.FullName;
            emp.Phone = a.Phone;
            emp.Gender = a.Gender;
            emp.Email = a.Email;
            emp.Address = a.Address;
            emp.PinCode = a.PinCode;

            return View("Create", emp);
        }

        public IActionResult Delete(int id)
        {
            var data = _db.StudentModels.Where(m => m.Student_ID == id).FirstOrDefault();
            if (data != null)
            {
                _db.StudentModels.Remove(data);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg = "Tuple not exists";
                return RedirectToAction("Index");
            }


        }



        public IActionResult CourseIndex()
        {
            var a = _db.CourseModels.ToList();
            //DummyEmployeeModel m = new DummyEmployeeModel();
            List<CourseModel> list = new List<CourseModel>();
            foreach (var i in a)
            {
                list.Add(new CourseModel()
                {
                    Course_ID = i.Course_ID,
                    CourseName = i.CourseName,
                    CourseFee = i.CourseFee,
                    CourseDuration = i.CourseDuration,
                    TeacherName = i.TeacherName

                });
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult CourseCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CourseCreate(CourseModel demp)
        {
            CourseModel emp = new CourseModel();
            emp.Course_ID = demp.Course_ID;
            emp.CourseName = demp.CourseName;
            emp.CourseFee = demp.CourseFee;
            emp.CourseDuration = demp.CourseDuration;
            emp.TeacherName = demp.TeacherName;


            if (emp.Course_ID == 0)
            {
                _db.CourseModels.Add(emp);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
            }
            return RedirectToAction("CourseIndex");
        }
        [HttpGet]
        public IActionResult CourseEdit(int id)
        {
            var a = _db.CourseModels.Where(m => m.Course_ID == id).FirstOrDefault();
            CourseModel emp = new CourseModel();
            emp.Course_ID = a.Course_ID;
            emp.CourseName = a.CourseName;
            emp.CourseFee = a.CourseFee;
            emp.CourseDuration = a.CourseDuration;
            emp.TeacherName = a.TeacherName;


            return View("CourseCreate", emp);
        }

        public IActionResult CourseDelete(int id)
        {
            var data = _db.CourseModels.Where(m => m.Course_ID == id).FirstOrDefault();
            if (data != null)
            {
                _db.CourseModels.Remove(data);
                _db.SaveChanges();
                return RedirectToAction("CourseIndex");
            }
            else
            {
                ViewBag.Msg = "Tuple not exists";
                return RedirectToAction("CourseIndex");
            }


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

