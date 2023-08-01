using CaseStudy.Data.Abstract;
using CaseStudy.Data.Context;
using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Data.Concrete
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly CaseStudyContext _context;
        public CartRepository(CaseStudyContext context) : base(context)
        {
            _context = context;

        }

        public IQueryable<Cart> GetCart(int userID)
        {
            var userCart = _context.Cart.Include(n => n.Product).Where(n => n.UserID == userID);

            return userCart;
        }
    }
}
