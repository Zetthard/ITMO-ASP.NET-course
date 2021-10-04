using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamScoreSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<ExamMark> Marks { get; set; }

        public override string ToString()
        {
            string str = FirstName + " " + LastName;
            return str;
        }
    }
}