using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Data;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Controllers.API
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        [HttpGet("{id?}")]
        public Customers GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception("customer not found");
            }
            return customer;
        }
        [HttpPost]
        public Customers CreateCustomer([FromBody]Customers customer)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Could not create customer");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}
