using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicWebApp.Models;

namespace DynamicWebApp.Controllers
{
    public class ApplicationUser : Controller
    {
        public ActionResult Index()
        {
            var user = new Models.ApplicationUser();

            return View(user);
        }

        public ViewResult Dynamic(Models.ApplicationUser user)
        {
            /// Linq expression to save user to database
            Console.WriteLine(user.Attributes.Count);
            return View();
        }
        
    }
}
