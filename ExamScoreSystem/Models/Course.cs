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

        public virtual List<ExamMark> CourseMarks { get; set; }

        public override string ToString()
        {
            return CourseName;
        }
    }
}