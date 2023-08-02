using CaseStudy.Business.Result;
using CaseStudy.Dto.Cart;
using CaseStudy.Dto.Order;
using CaseStudy.Dto.Payment;
using CaseStudy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Abstract
{
    public interface IOrderManager
    {
        Task<IDataResult<List<GetOrderListDto>>> GetOrderListByUserID(int userID);
        Task<List<Order>> CreateOrderList(List<CartListDto> cardProducts, int userID);
    }
}
