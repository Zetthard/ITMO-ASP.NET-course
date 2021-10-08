using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual List<Exam> Exams { get; set; }

        public override string ToString()
        {
            string str = FirstName + " " + LastName;
            return str;
        }
    }
}