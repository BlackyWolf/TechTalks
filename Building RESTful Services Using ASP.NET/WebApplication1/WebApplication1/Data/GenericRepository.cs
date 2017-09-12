using WebApplication1.Data.Sources;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class GenericRepository : Repository
    {
        public GenericRepository()
        {
            Customers = new Source<Customer>();
            Invoices = new Source<Invoice>();
            Orders = new Source<Order>();
            Products = new Source<Product>();
        }
    }
}