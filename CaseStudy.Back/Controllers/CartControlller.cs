using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Business.Factories;
using CaseStudy.Dto.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CaseStudy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartControlller : ControllerBase
    {
        private readonly ICartManager _cartManager;
        public CartControlller(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IDataResult<GetCartDto>> GetCart()
        {
            var result = await _cartManager.GetCart(Convert.ToInt32(User.Identity));
            if (result.Success)
            {
                return result;
            }
            return new ErrorDataResult<GetCartDto>(result.Message, result.Code);
        }
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IDataResult<AddedCartDto>> AddToCart(AddCartDto addCart)
        {
            var cart = await _cartManager.AddToCart(addCart);
            if (cart != null)
            {
                return cart;
            }
            return new ErrorDataResult<AddedCartDto>(cart.Message, cart.Code);
        }
    }
}
