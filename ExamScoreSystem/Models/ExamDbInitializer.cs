using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{
    public class ExamDbInitializer : DropCreateDatabaseIfModelChanges<ExamContext>
    {
        protected override void Seed(ExamContext context)
        {
            context.Courses.Add(new Course { CourseName = "ADO.NET" });
            context.Courses.Add(new Course { CourseName = "ASP.NET" });
            context.Courses.Add(new Course { CourseName = "C# programming" });
            context.Courses.Add(new Course { CourseName = "Databases" });

            context.Students.Add(new Student { FirstName = "Tom", LastName = "Soyer" });
            context.Students.Add(new Student { FirstName = "Vinni", LastName = "Pooh" });
            context.Students.Add(new Student { FirstName = "Alice", LastName = "Mirrorgirl" });
            context.Students.Add(new Student { FirstName = "Tumba", LastName = "Lumumba" });
            context.Students.Add(new Student { FirstName = "King", LastName = "Kong" });
            context.Students.Add(new Student { FirstName = "Dragon", LastName = "Pu" });

            context.SaveChanges();

            context.Exams.Add(new Exam { StudentId = 1, CourseId = 1, Mark = 3 });
            context.Exams.Add(new Exam { StudentId = 1, CourseId = 2, Mark = 4 });
            context.Exams.Add(new Exam { StudentId = 3, CourseId = 1, Mark = 5 });
            context.Exams.Add(new Exam { StudentId = 4, CourseId = 1, Mark = 4 });
            context.Exams.Add(new Exam { StudentId = 5, CourseId = 2, Mark = 5 });

            context.SaveChanges();
            //base.Seed(context);
        }
    }
}