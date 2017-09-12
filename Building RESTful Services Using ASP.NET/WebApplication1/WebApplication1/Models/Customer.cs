using System;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}