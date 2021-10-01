using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCreditApp.Models
{
    public class Credit
    {
        public virtual int CreditId { get; set; }
        public virtual string Head { get; set; }
        public virtual int Period { get; set; }
        public virtual int Amount { get; set; }
        public virtual int Rate { get; set; } 
    }
}