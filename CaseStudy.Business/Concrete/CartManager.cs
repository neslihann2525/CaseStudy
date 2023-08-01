using AutoMapper;
using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Data.Abstract;
using CaseStudy.Dto.Cart;
using CaseStudy.Entities.Models;
using static CaseStudy.Business.Factories.DifferentImplementationsFactoryExtension;

namespace CaseStudy.Business.Concrete
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository _cartRepository;
        private readonly IRepositoryFactory<Cart> _factory;
        private readonly IMapper _mapper;
        IRepository<Cart>? repository;
        public CartManager(ICartRepository cartRepository,
            IRepositoryFactory<Cart> factory,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _factory = factory;
            _mapper = mapper;

            repository = _factory.Create();

        }
        
        public async Task<IDataResult<AddedCartDto>> AddToCart(AddCartDto addCart)
        {
            var convertCart = _mapper.Map<Cart>(addCart);
            try
            {
                var addedCart = await repository!.Create(convertCart);
                if (addedCart != null)
                {
                    return new SuccessDataResult<AddedCartDto>(_mapper.Map<AddedCartDto>(addedCart));
                }
            }
            catch (Exception ex)
            {

            }
            return new ErrorDataResult<AddedCartDto>(new List<string> { "" }, "");
        }

        public async Task<IResult> RemoveFromCart(int cartId)
        {
            var findCart = await repository!.GetFirstByFilter(n => n.CartID == cartId);
            var removedCart = await repository!.Remove(findCart);
            if (removedCart)
            {
                return new SuccessResult();
            }
            return new ErrorResult(new List<string> { "" }, "");
        }
        public async Task<IResult> RemoveCartByUserID(int userID)
        {
            var removedCart = await repository!.RemoveAllByFilter(n => n.UserID == userID);
            if (removedCart)
            {
                return new SuccessResult();
            }
            return new ErrorResult(new List<string> { "" }, "");
        }

        public async Task<IDataResult<GetCartDto>> GetCart(int userID)
        {
            var userCart = _cartRepository.GetCart(userID);
            GetCartDto carts = new GetCartDto();

            var result = userCart.GroupBy(item => item.ProductID)
                                 .Select(group => new
                                 {
                                     ProductID = group.Key,
                                     TotalQuantity = group.Sum(item => item.Quantity)
                                 })
                                 .ToList();

            carts.CartList = _mapper.Map<List<CartListDto>>(userCart.GroupBy(n => n.ProductID));
            carts.CartList.ForEach(n => n.Quantity = result.FirstOrDefault(x => x.ProductID == n.ProductID)?.TotalQuantity ?? 0);
            carts.TotalCost = userCart.Sum(x => x.Product.Price);

            if (userCart != null)
            {
                return new SuccessDataResult<GetCartDto>(carts);
            }
            return new ErrorDataResult<GetCartDto>(new List<string> { "" }, "");
        }
    }
}
