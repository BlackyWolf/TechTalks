using System;
using WebApplication1.Models.Enums;

namespace WebApplication1.Models
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