using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{
    public class ExamMark
    {
        public int ExamMarkId { get; set; }

        private int mark;

        public int Mark
        {
            get { return mark; }

            private set
            {
                if (value >= 1 && value <= 5)
                    mark = value;
            }
        }

        [Required]
        public Student StudentName { get; set; }

        [Required]
        public Course CourseName { get; set; }

        public ExamMark(int m, Student student, Course course)
        {
            Mark = m;
            StudentName = student;
            CourseName = course;
        }
    }
}