using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Extensions;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly Repository repository;

        public InvoicesController(Repository repository)
        {
            this.repository = repository;
        }

        // GET: api/Customers
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.Invoices.Read());
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
                var invoice = repository.Invoices.Read(id);

                if (invoice == null) return NotFound();

                return Ok(invoice);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("api/invoices/{id:int}/customer")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var invoice = repository.Invoices.Read(id);

                if (invoice == null) return NotFound();

                var customer = repository.Customers.FirstOrDefault(x => x.Id == invoice.CustomerId);

                if (customer == null) return NotFound();

                return Ok(customer);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/Customers
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                repository.Orders.Add(order);

                return Created($"api/Customers/{order.Id}", order);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Customers/5
        public IActionResult Put(int id, [FromBody] Order updatedOrder)
        {
            try
            {
                if (id < 1) return BadRequest("The order ID is required.");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                var currentOrder = repository.Orders.Read(id);

                if (currentOrder == null) return Post(updatedOrder);

                currentOrder.Update(updatedOrder);
                
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
                if (id < 1) return BadRequest("The order ID is required.");
                
                var order = repository.Orders.Read(id);
                
                if (order == null) return NotFound();

                repository.Orders.Remove(order);

                return Ok(order);
            }
            catch
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
