using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicWebApp.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public List<Attributes> Attributes { get; set; }
        public ApplicationUser()
        {
            Attributes = new List<Attributes>();
            Attributes.Add(new Attributes { Name = "FirstName"});
            Attributes.Add(new Models.Attributes { Name = "LastName"});
        }
    }
    public class Attributes
    {
        public string Name { get; set; }
    }
}
