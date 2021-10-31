using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using ExamScoreSystem.Models;
using System.Data;
using System.Net;

namespace ExamScoreSystem.Controllers
{
    public class HomeController : Controller
    {
        private ExamContext context = new ExamContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            return View(context.Students.ToList());
        }

        public ActionResult ShowTop5()
        {
            var students = context.Students.Include(s => s.Exams).ToList();
            var top5 = (from s in students
                       orderby s.Total descending
                       select s).Take(5);
                       
            return View(top5);
        }

        public ActionResult ShowBottom5()
        {
            var students = context.Students.Include(s => s.Exams).ToList();
            var bottom5 = (from s in students
                        orderby s.Total
                        select s).Take(5);

            return View(bottom5);
        }

        public ActionResult StudentDetails(int? id)
        {
            Student student = context.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }
        public ActionResult Courses()
        {
            return View(context.Courses.ToList());
        }

        public ActionResult CourseDetails(int? id)
        {
            Course course = context.Courses.Find(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
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
        public ActionResult EditExam(int? sId, int? cId)
        {
            try
            {
                Exam exam = context.Exams
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Where(s => s.StudentId == sId)
                .Where(c => c.CourseId == cId)
                .Single();
            
                if (exam == null)
                    return HttpNotFound();
                return View(exam);
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError("", "Unable to retrieve single entity");
                return RedirectToAction("Courses");
            }
        }

        [HttpPost, ActionName("EditExam")]
        public ActionResult SubmitExam(int? sId, int? cId)
        {
            if (sId == null || cId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = context.Exams.Find(cId, sId);
            if (TryUpdateModel(exam, "", new string[] { "StudentId", "CourseId", "Mark" }))
            {
                try
                {
                    context.SaveChanges();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
            }
            return RedirectToAction("CourseDetails", new { id = exam.CourseId });
        }

        public ActionResult AddExam(int? CourseId)
        {            
            ICollection<Student> students = context.Students.ToList();

            ViewBag.StudentId = new SelectList(students, "StudentId", "FullName");
            ViewBag.CourseName = context.Courses.Find(CourseId).CourseName;

            return View();
        }

        [HttpPost]
        public ActionResult AddExam([Bind(Include = "CourseId, StudentId, Mark")] Exam exam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Exams.Add(exam);
                    context.SaveChanges();
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            return RedirectToAction("CourseDetails", new { id = exam.CourseId });
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}