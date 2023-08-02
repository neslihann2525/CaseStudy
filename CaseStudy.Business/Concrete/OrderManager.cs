using AutoMapper;
using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Data.Abstract;
using CaseStudy.Dto.Cart;
using CaseStudy.Dto.Order;
using CaseStudy.Dto.Payment;
using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Business.Concrete
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderManager(IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<AddedOrderDto>> AddToOrder(AddOrderDto addOrder)
        {
            var convertOrder = _mapper.Map<Order>(addOrder);
            var addedOrder = await _orderRepository.Create(convertOrder);
            if (addedOrder != null)
            {
                return new SuccessDataResult<AddedOrderDto>(_mapper.Map<AddedOrderDto>(addedOrder));
            }
            return new ErrorDataResult<AddedOrderDto>(new List<string> { "" }, "");
        }

        public async Task<IDataResult<List<GetOrderListDto>>> GetOrderListByUserID(int userID)
        {
            var orderList = _orderRepository.GetOrderListByUserID(userID);
            if (orderList != null)
            {
                return new SuccessDataResult<List<GetOrderListDto>>(await orderList.ToListAsync());
            }
            return new ErrorDataResult<List<GetOrderListDto>>(new List<string> { "" }, "");
        }

        public async Task<List<Order>> CreateOrderList(List<CartListDto> cardProducts, int userID)
        {
            var orderList = new List<Order>();

            foreach (var cardProduct in cardProducts)
            {
                var order = new Order
                {
                    UserID = userID,
                    ProductID = cardProduct.ProductID,
                    Quantity = cardProduct.Quantity,
                    CreatedDate = DateTime.Now
                };
                orderList.Add(order);
            }

            await _orderRepository.CreateList(orderList);

            return orderList;
        }
    }
}
