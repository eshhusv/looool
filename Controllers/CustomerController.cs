using looool.Models;
using Microsoft.AspNetCore.Mvc;

namespace looool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private DataContext db;
        public CustomerController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Customer> GetCustomer()
        {
            return db.Customers.ToList();
        }
        [HttpGet("{id}")]
        public Customer GetCustomers(int id)
        {
            return db.Customers.Where(p => p.CustomerId == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveCustomers([FromBody] Customer customer)
        {
            if(customer != null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public async Task<ActionResult<Customer>> Put(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!db.Customers.Any(x => x.CustomerId == customer.CustomerId))
            {
                return NotFound();
            }
            db.Update(customer);
            await db.SaveChangesAsync();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public void DeleteCustomers(long id)
        {
            db.Customers.Remove(db.Customers.Where(p => p.CustomerId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}