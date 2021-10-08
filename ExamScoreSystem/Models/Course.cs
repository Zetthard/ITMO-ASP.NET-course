using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [StringLength(60)]
        public string CourseName { get; set; }

        public virtual List<Exam> Exams { get; set; }
    }
}