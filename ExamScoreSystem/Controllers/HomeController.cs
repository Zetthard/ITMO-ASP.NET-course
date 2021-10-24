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
        public ActionResult Courses()
        {
            return View(context.Courses.ToList());
        }

        public ActionResult CourseDetails(int? id)
        {
            ViewBag.Students = context.Students.ToList(); //check if needed?
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

        [HttpPost, ActionName("EditExam")]
        public ActionResult SubmitExam(int? ExamId)
        {
            if (ExamId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = context.Exams.Find(ExamId);
            if (TryUpdateModel(exam, "", new string[] { "StudentId", "CourseId", "Mark", "ExamId" }))
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