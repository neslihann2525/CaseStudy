using AutoMapper;
using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Data.Abstract;
using CaseStudy.Data.Concrete;
using CaseStudy.Dto.Order;
using CaseStudy.Dto.Product;
using CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Concrete
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository repository,
            IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetProductDto>>> GetProductList()
        {
            var list = await _repository.GetAll();
            if (list != null)
            {
                return new SuccessDataResult<List<GetProductDto>>(_mapper.Map<List<GetProductDto>>(list));
            }
            return new ErrorDataResult<List<GetProductDto>>(new List<string> { "" }, "");
        }

        public async Task<IDataResult<List<GetProductDto>>> GetProductsByIds(List<int> ids)
        {
            var products = _repository.GetProducts(ids);
            if (products != null)
            {
                return new SuccessDataResult<List<GetProductDto>>(await products.ToListAsync());

            }
            return new ErrorDataResult<List<GetProductDto>>(new List<string> { "" }, "");
        }

        public async Task<IResult> SetProductQuantity(List<int> cardProducts)
        {
            var orderList = new List<Order>();

            foreach (var cardProduct in cardProducts)
            {
            var product = await _repository.GetFirstByFilter(n => n.ProductID == cardProduct);
                if (product != null)
                {
                    product.Quantity = product.Quantity--;
                    var result = await _repository.Update(product);
                    if (result)
                    {
                        return new SuccessResult();
                    }
                }
            }

            return new ErrorDataResult<IResult>(new List<string> { "" }, "");
        }
    }
}
