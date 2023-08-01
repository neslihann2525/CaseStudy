using CaseStudy.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities.Models
{
    public class Order : IOrder
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }

        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
