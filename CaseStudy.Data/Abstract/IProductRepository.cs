using CaseStudy.Dto.Product;
using CaseStudy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<GetProductDto> GetProducts(List<int> ids);
    }
}
