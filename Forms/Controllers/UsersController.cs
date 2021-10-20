using Forms.Data;
using Forms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        public IActionResult Edit(int Id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Save(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = _context.Users.SingleOrDefault(c => c.Id == user.Id);
            data.FirstName = user.FirstName;
            data.LastName = user.LastName;
            data.Email = user.Email;
            data.Password = user.Password;
            _context.Users.Update(data);
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}
