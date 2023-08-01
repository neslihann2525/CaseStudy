using CaseStudy.Entities.Models;

namespace CaseStudy.Data.Abstract
{
    public interface ICartRepository
    {
        IQueryable<Cart> GetCart(int userID);
    }
}
