using Forms.Data;
using Forms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Forms.Controllers.api
{
    [Microsoft.AspNetCore.Mvc.Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCustomer(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetCustomers()
        {
            var data = _context.Users.ToList();
            return Json(new { data=data});
        }
        
    }
}
