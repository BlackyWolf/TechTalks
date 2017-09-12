using System;
using WebApplication2.Models.Enums;

namespace WebApplication2.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateCreated { get; set; }

        public int InvoiceId { get; set; }

        public OrderStatus Status { get; set; }
    }
}