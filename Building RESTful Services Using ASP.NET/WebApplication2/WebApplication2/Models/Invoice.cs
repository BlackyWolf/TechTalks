using System;
using WebApplication2.Models.Enums;

namespace WebApplication2.Models
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