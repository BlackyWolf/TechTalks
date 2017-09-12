using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApplication1.Data;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly Repository repository;

        public CustomersController()
        {
            repository = new Repository();
        }

        // GET: api/Customers
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.Customers.Read());
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // GET: api/Customers/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var customer = repository.Customers.Read(id);

                if (customer == null) return NotFound();

                return Ok(customer);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        [Route("api/customers/{id:int}/orders")]
        public IHttpActionResult GetOrders(int id)
        {
            try
            {
                var orders = repository.Orders.Where(x => x.CustomerId == id);
                
                return Ok(orders);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }
        
        [Route("api/customers/{id:int}/invoices")]
        public IHttpActionResult GetInvoices(int id)
        {
            try
            {
                var invoices = repository.Invoices.Where(x => x.CustomerId == id);

                return Ok(invoices);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // POST: api/Customers
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                repository.Customers.Add(customer);

                return Created($"api/Customers/{customer.Id}", customer);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // PUT: api/Customers/5
        public IHttpActionResult Put(int id, [FromBody] Customer updatedCustomer)
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
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // DELETE: api/Customers/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id < 1) return BadRequest("The customer ID is required.");
                
                var customer = repository.Customers.Read(id);
                
                if (customer == null) return NotFound();

                repository.Customers.Remove(customer);

                return Ok(customer);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }
    }
}
