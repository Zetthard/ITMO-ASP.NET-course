using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ExamScoreSystem.Models
{
    public class ExamDbInitializer : DropCreateDatabaseIfModelChanges<ExamContext>
    {
        protected override void Seed(ExamContext context)
        {
            var courses = new List<Course>()
            {
                new Course { CourseName = "C# programming" },
                new Course { CourseName = "Databases" },
                new Course { CourseName = "ADO.NET" },
                new Course { CourseName = "ASP.NET" }
            };

            courses.ForEach(item => context.Courses.Add(item));
            context.SaveChanges();

            var students = new List<Student>()
            {
                new Student { FirstName = "Tom", LastName = "Soyer" },
                new Student { FirstName = "Vinni", LastName = "Pooh" },
                new Student { FirstName = "Alice", LastName = "Mirrorgirl" },
                new Student { FirstName = "Tumba", LastName = "Lumumba" },
                new Student { FirstName = "King", LastName = "Kong" },
                new Student { FirstName = "Dragon", LastName = "Pu" }
            };

            students.ForEach(item => context.Students.Add(item));
            context.SaveChanges();

            foreach(Course c in courses)
            {
                foreach(Student s in students)
                {
                    context.Exams.Add(new Exam {CourseId = c.CourseId, StudentId = s.StudentId });
                }
            }

            context.SaveChanges();
            context.Exams.Where(c => c.CourseId == 1).ToList().ForEach(s => s.Mark = 5);  //option 1
            foreach(var exam in context.Exams.Where(c => c.CourseId == 2)) //option 2
            {
                exam.Mark = 5;
            }
            //base.Seed(context);
        }
    }
}