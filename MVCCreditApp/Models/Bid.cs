using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCreditApp.Models
{
    public class Bid
    {
        public virtual int BidId { get; set; }

        [Required]
        [DisplayName("Имя заявителя")]
        public virtual string CustomerName { get; set; }

        [Required]
        [DisplayName("Тип кредита")]
        public virtual string CreditHead { get; set; }

        [DisplayName("Дата подачи заявки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public virtual DateTime BidDate { get; set; }
    }
}