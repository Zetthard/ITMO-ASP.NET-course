using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RSVPsite
{
    public class GuestResponse
    {
        public int GuestResponseId { get; set; }
        public string Name { get; set;}
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
        public DateTime Rdate { get; set; }

        public virtual List<Report> Reports { get; set; }

        public GuestResponse() { }
        public GuestResponse(string name, string email, string phone, bool? willattend)
        {
            Name = name;
            Email = email;
            Phone = phone;
            WillAttend = willattend;
            Rdate = DateTime.Now;
            Reports = new List<Report>();
        }
    }

    public class Report
    {
        public int ReportID { get; set; }
        public string ReportTitle { get; set; }
        public string Annotation { get; set; }
        public GuestResponse GResponse { get; set; }

        public Report() { }
        public Report(string title, string annot)
        {
            ReportTitle = title;
            Annotation = annot;
        }
    }
}