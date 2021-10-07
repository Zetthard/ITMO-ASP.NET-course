using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{ 
    public class Exam
    {
        public int ExamId { get; set; }

        private int mark;

        [Range(1, 5)]
        public int Mark
        {
            get { return mark; }

            set
            {
                if (value >= 1 && value <= 5)
                    mark = value;
            }
        }

        public Student StudentName { get; set; }

        public Course CourseName { get; set; }

        //public Exam() { }

        public Exam(int mark)
        {
            Mark = mark;
        }
    }
}