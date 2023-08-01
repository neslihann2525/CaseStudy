﻿using CaseStudy.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Entities.Models
{
    public class Cart : ICart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
