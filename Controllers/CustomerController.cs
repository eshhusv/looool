using looool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace looool.Controllers
{
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
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateCustomers([FromBody] Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteCustomers(long id)
        {
            db.Customers.Remove(db.Customers.Where(p => p.CustomerId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
