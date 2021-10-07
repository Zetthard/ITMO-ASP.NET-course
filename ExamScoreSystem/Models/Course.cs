using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual List<Exam> CourseMarks { get; set; }

        public override string ToString()
        {
            return CourseName;
        }

        public Course() { }

        public Course(string name)
        {
            CourseName = name;
            CourseMarks = new List<Exam>();
        }
    }
}