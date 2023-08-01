using CaseStudy.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities.Models
{
    public class Product : IProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public List<Order> Orders { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
