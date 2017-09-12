using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Extensions;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Repository repository;

        public CustomersController(Repository repository)
        {
            this.repository = repository;
        }

        // GET: api/Customers
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.Customers.Read());
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError); 
            }
        }

        // GET: api/Customers/5
        public IActionResult Get(int id)
        {
            try
            {
                var customer = repository.Customers.Read(id);

                if (customer == null) return NotFound();

                return Ok(customer);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("api/customers/{id:int}/orders")]
        public IActionResult GetOrders(int id)
        {
            try
            {
                var orders = repository.Orders.Where(x => x.CustomerId == id);
                
                return Ok(orders);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
        
        [Route("api/customers/{id:int}/invoices")]
        public IActionResult GetInvoices(int id)
        {
            try
            {
                var invoices = repository.Invoices.Where(x => x.CustomerId == id);

                return Ok(invoices);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/Customers
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                repository.Customers.Add(customer);

                return Created($"api/Customers/{customer.Id}", customer);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Customers/5
        public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        {
            try
            {
                if (id < 1) return BadRequest("The customer ID is required.");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                var currentCustomer = repository.Customers.Read(id);

                if (currentCustomer == null) return Post(updatedCustomer);

                currentCustomer.Update(updatedCustomer);
                
                return Ok();
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Customers/5
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 1) return BadRequest("The customer ID is required.");
                
                var customer = repository.Customers.Read(id);
                
                if (customer == null) return NotFound();

                repository.Customers.Remove(customer);

                return Ok(customer);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
