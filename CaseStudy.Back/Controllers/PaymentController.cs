using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Dto.Payment;
using CaseStudy.Dto.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace CaseStudy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<Business.Result.IResult> PaymentCart(PaymentProcessDto paymentProcess)
        {
            var result = await _paymentManager.PaymentProcess(paymentProcess.CardProducts, paymentProcess.Payment, Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            if (result.Success)
            {
                return new SuccessResult();
            }

            return new ErrorResult(new List<string> { "" }, "");
        }
    }
}
