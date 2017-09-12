using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApplication1.Data;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InvoicesController : ApiController
    {
        private readonly Repository repository;

        public InvoicesController()
        {
            repository = new Repository();
        }

        // GET: api/Customers
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.Invoices.Read());
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // GET: api/Customers/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var invoice = repository.Invoices.Read(id);

                if (invoice == null) return NotFound();

                return Ok(invoice);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        [Route("api/invoices/{id:int}/customer")]
        public IHttpActionResult GetCustomer(int id)
        {
            try
            {
                var invoice = repository.Invoices.Read(id);

                if (invoice == null) return NotFound();

                var customer = repository.Customers.FirstOrDefault(x => x.Id == invoice.CustomerId);

                if (customer == null) return NotFound();

                return Ok(customer);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // POST: api/Customers
        public IHttpActionResult Post([FromBody] Invoice invoice)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                repository.Invoices.Add(invoice);

                return Created($"api/Invoices/{invoice.Id}", invoice);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }

        // PUT: api/Customers/5
        public IHttpActionResult Put(int id, [FromBody] Invoice updatedInvoice)
        {
            try
            {
                if (id < 1) return BadRequest("The order ID is required.");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                var currentInvoice = repository.Invoices.Read(id);

                if (currentInvoice == null) return Post(updatedInvoice);

                currentInvoice.Update(updatedInvoice);
                
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
                
                var invoice = repository.Invoices.Read(id);
                
                if (invoice == null) return NotFound();

                repository.Invoices.Remove(invoice);

                return Ok(invoice);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, new SanitizedException(exception));
            }
        }
    }
}
