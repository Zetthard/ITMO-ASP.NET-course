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

            base.Seed(context);
        }
    }
}