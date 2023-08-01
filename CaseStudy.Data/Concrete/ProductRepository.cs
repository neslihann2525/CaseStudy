using CaseStudy.Data.Abstract;
using CaseStudy.Data.Context;
using CaseStudy.Dto.Product;
using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly CaseStudyContext _context;
        public ProductRepository(CaseStudyContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<bool> Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public IQueryable<GetProductDto> GetProducts(List<int> ids)
        {
            return _context.Product.Where(n => ids.Contains(n.ProductID)).Select(c => new GetProductDto
            {
                ProductID = c.ProductID,
                Name = c.Name,
                Price = c.Price,
                Quantity = c.Quantity
            });
        }
    }
}
