using CaseStudy.Data.Abstract;
using CaseStudy.Data.Context;
using CaseStudy.Dto.Order;
using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Concrete
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly CaseStudyContext _context;
        public OrderRepository(CaseStudyContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<GetOrderListDto> GetOrderListByUserID(int userId)
        {
            var result = _context.Order.Include(n => n.Product).Where(n => n.UserID == userId)
                .Select(p =>
                new GetOrderListDto
                {
                    OrderID = p.OrderID,
                    ProductID = p.ProductID,
                    ProductName = p.Product.Name,
                    UserID = p.UserID
                });
            return result;
        }
    }
}
