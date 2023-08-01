using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dto.Payment
{
    public class PaymentDto
    {
        public string? CardNo { get; set; }
        public int CardMonth { get; set; }
        public int CardYear { get; set; }
        public int CVC { get; set; }

        //gerekli olabilecek başka property'ler eklenebilir..
    }
}
