using AutoMapper;
using CaseStudy.Dto.AppUser;
using CaseStudy.Dto.Cart;
using CaseStudy.Dto.Order;
using CaseStudy.Dto.Payment;
using CaseStudy.Dto.Product;
using CaseStudy.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Backend.AutoMapperProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, SignUpRequestDto>().ReverseMap();
            CreateMap<SignUpRequestDto, AppUser>().ReverseMap();

            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<GetProductDto, Product>().ReverseMap();

            CreateMap<Product,ProductAddDto>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();

            CreateMap<Cart, GetCartDto>().ReverseMap();
            CreateMap<GetCartDto, Cart>().ReverseMap();

            CreateMap<Cart, CartListDto>().ReverseMap();
            CreateMap<CartListDto, Cart>().ReverseMap();

            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<AddOrderDto, Order>().ReverseMap();

            CreateMap<Order, GetOrderListDto>().ReverseMap();
            CreateMap<GetOrderListDto, Order>().ReverseMap();

            CreateMap<Cart, AddedCartDto>().ReverseMap();
            CreateMap<AddedCartDto,Cart>().ReverseMap();

            CreateMap<Cart, AddCartDto>().ReverseMap();
            CreateMap<AddCartDto, Cart>().ReverseMap();
        }
    }
}
