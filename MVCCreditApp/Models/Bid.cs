using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCreditApp.Models
{
    public class Bid
    {
        public virtual int BidId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CreditHead { get; set; }
        public virtual DateTime BidDate { get; set; }
    }
}