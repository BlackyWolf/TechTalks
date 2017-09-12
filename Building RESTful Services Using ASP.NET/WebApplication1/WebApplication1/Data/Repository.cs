using WebApplication1.Data.Sources;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Repository
    {
        public ISource<Customer> Customers { get; set; }

        public ISource<Invoice> Invoices { get; set; }

        public ISource<Order> Orders { get; set; }

        public ISource<Product> Products { get; set; }

        public Repository()
        {
            Customers = new CustomerSource();
            Invoices = new InvoiceSource();
            Orders = new OrderSource();
            Products = new ProductSource();
        }
    }
}