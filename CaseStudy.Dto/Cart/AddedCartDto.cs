﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dto.Cart
{
    public class AddedCartDto
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
