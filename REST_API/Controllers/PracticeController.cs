using Microsoft.AspNetCore.Mvc;
using REST_API.Data;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Controllers
{
    public class PracticeController : Controller
    {
        private ApplicationDbContext _context;
        public PracticeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
