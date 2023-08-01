using CaseStudy.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dto.Payment
{
    public class PaymentProcessDto
    {
        public List<ProductAddDto> CardProducts { get; set; }
        public PaymentDto Payment { get; set; }
    }
}
