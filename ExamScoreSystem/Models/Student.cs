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

        public int? Total => GetTotal();

        public virtual List<Exam> Exams { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int? GetTotal()
        {
            return Exams.Sum(x => x.Mark);
        }
    }
}