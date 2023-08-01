using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? Address { get; set; }


        public List<Cart> Carts{ get; set; }
        public List<Order> Orders { get; set; }
    }
}
