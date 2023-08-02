using CaseStudy.Business.Result;
using CaseStudy.Dto.Cart;
using CaseStudy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Abstract
{
    public interface ICartManager
    {
        Task<IDataResult<GetCartDto>> GetCart(int userID);
        Task<IResult> RemoveFromCart(int cartId);
        Task<IResult> RemoveCartByUserID(int userID);
        Task<IDataResult<AddedCartDto>> AddToCart(AddCartDto addCart);
        Task<IDataResult<List<CartListDto>>> GetCartByUserID(int userID);
    }
}
