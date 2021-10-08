using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamScoreSystem.Models;

namespace ExamScoreSystem.Controllers
{
    public class HomeController : Controller
    {
        private ExamContext context = new ExamContext();

        public ActionResult Index()
        {
            return View(context.Students.ToList());
        }

        public ActionResult Students()
        {
            return View(context.Students.ToList());
        }

        public ActionResult StudentDetails(int? id)
        {
            Student student = context.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        public ActionResult CourseDetails(int? id)
        {
            Course course = context.Courses.Find(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }

        public ActionResult Courses()
        {
            return View(context.Courses.ToList());
        }

        private void GetCourses()
        {
            var allCourses = context.Courses.ToList();
            ViewBag.Courses = allCourses;
        }

        private void GetStudents()
        {
            var allStudents = context.Students.ToList();
            ViewBag.Students = allStudents;
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student newStudent)
        {
            if(ModelState.IsValid)
            {
                context.Students.Add(newStudent);
                context.SaveChanges();
            }
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult EnterExam()
        {
            GetStudents();
            GetCourses();
            return View();
        }

        [HttpPost]
        public ActionResult EnterExam(Exam mark)
        {
            if (ModelState.IsValid)
            {
                context.Exams.Add(mark);
                context.SaveChanges();
            }
            else
            {
                return View("Courses", context.Courses);
            }
            return View();
        }
    }
}