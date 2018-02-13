using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DatePaid { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public virtual InvoiceType InvoiceType { get; set; }
    }
}