using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Business.Factories;
using CaseStudy.Dto.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AutoMapper;

namespace CaseStudy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartControlller : ControllerBase
    {
        private readonly ICartManager _cartManager;
        private readonly IMapper _mapper;
        public CartControlller(ICartManager cartManager, IMapper mapper)
        {
            _cartManager = cartManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IDataResult<GetCartDto>> GetCart()
        {
            var result = await _cartManager.GetCart(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            if (result.Success)
            {
                return result;
            }
            return new ErrorDataResult<GetCartDto>(result.Message, result.Code);
        }
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IDataResult<AddedCartDto>> AddToCart(AddCartParameterDto addCart)
        {
            AddCartDto addCartDto = _mapper.Map<AddCartDto>(addCart);
            addCartDto.UserID = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cart = await _cartManager.AddToCart(addCartDto);
            if (cart != null)
            {
                return cart;
            }
            return new ErrorDataResult<AddedCartDto>(cart.Message, cart.Code);
        }
    }
}
