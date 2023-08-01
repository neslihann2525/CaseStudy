using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dto.Cart
{
    public class GetCartDto
    {
        public List<CartListDto> CartList { get; set; }
        public decimal TotalCost { get; set; }
    }
}
