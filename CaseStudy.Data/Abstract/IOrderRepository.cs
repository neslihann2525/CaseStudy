using CaseStudy.Dto.Order;
using CaseStudy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<GetOrderListDto> GetOrderListByUserID(int userId);
    }
}
