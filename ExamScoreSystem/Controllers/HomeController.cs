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
            GetStudents();
            GetCourses();
            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Message = "List of registered students";
            GetStudents();
            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "List of courses";
            GetCourses();
            return View();
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
            GetStudents();
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student newStudent)
        {
            context.Students.Add(newStudent);
            context.SaveChanges();
            return View("Students");
        }
    }
}