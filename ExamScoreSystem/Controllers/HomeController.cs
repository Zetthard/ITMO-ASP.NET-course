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
            Student student = context.Students.Find(sId);
            var exam = from exams in context.Exams
                       where exams.StudentId == sId && exams.CourseId == cId
                       select exams;
            if (student == null)
                return HttpNotFound();
            return View(exam);
        }

        [HttpPost, ActionName("EditExam")]
        public ActionResult SubmitExam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = context.Exams.Find(id);
            try
            {
                context.Entry(exam).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            return RedirectToAction("CourseDetails", ViewBag.CourseId);
            //return View();
        }

        [HttpPost, ActionName("SaveExam")]
        public ActionResult SaveExam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = context.Courses.Find(id);
            try
            {
                context.Entry(course).State = EntityState.Modified;
                context.SaveChanges();
                //return RedirectToAction("CourseDetails", id);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            return View(course);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}