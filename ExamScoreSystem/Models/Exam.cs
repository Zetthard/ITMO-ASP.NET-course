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
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        private int? mark;

        public int? Mark { get => mark;
            set
            {
                if (value >= 1 && value <= 5)
                    mark = value;
            }
        }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}