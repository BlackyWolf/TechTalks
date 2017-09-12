using System;
using WebApplication1.Models.Enums;

namespace WebApplication1.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateDue { get; set; }

        public InvoiceStatus Status { get; set; }
    }
}