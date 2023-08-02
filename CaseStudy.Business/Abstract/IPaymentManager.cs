using CaseStudy.Business.Result;
using CaseStudy.Dto.Payment;
using CaseStudy.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Abstract
{
    public interface IPaymentManager
    {
        Task<IResult> Payment(PaymentDto payment);
        Task<IResult> PaymentProcess(PaymentDto payment, int userID);
    }
}
