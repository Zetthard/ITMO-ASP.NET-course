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

        [Range(1, 5, ErrorMessage = "Must be between 1 and 5")]
        public int? Mark { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}