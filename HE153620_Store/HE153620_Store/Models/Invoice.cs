using System;
using System.Collections.Generic;

namespace HE153620_Store.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int? OrderId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Order? Order { get; set; }
    }
}
