using System;
using System.Net;
using System.Web.Http;
using WebApplication1.Data;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly Repository repository;

        public OrdersController()
        {
            repository = new Repository();
        }

        // GET: api/Customers
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.Orders.Read());
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
                var order = repository.Orders.Read(id);

                if (order == null) return NotFound();

                return Ok(order);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        [Route("api/orders/{id:int}/customer")]
        public IHttpActionResult GetCustomer(int id)
        {
            try
            {
                var order = repository.Orders.Read(id);

                if (order == null) return NotFound();

                var customer = repository.Customers.Read(order.CustomerId);

                if (customer == null) return NotFound();

                return Ok(customer);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }
        
        [Route("api/orders/{id:int}/invoice")]
        public IHttpActionResult GetInvoice(int id)
        {
            try
            {
                var order = repository.Orders.Read(id);

                if (order == null) return NotFound();

                var invoice = repository.Invoices.Read(order.InvoiceId);

                if (invoice == null) return NotFound();

                return Ok(invoice);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // POST: api/Customers
        public IHttpActionResult Post([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                repository.Orders.Add(order);

                return Created($"api/Customers/{order.Id}", order);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // PUT: api/Customers/5
        public IHttpActionResult Put(int id, [FromBody] Order updatedOrder)
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
                if (id < 1) return BadRequest("The order ID is required.");
                
                var order = repository.Orders.Read(id);
                
                if (order == null) return NotFound();

                repository.Orders.Remove(order);

                return Ok(order);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }
    }
}
