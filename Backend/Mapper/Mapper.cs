using APShopDTO;
using AutoMapper;
using System;
using EF = EfModels;


namespace Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<EF.User, User>().ReverseMap();

            CreateMap<EF.Cart, Cart>().ReverseMap();

            CreateMap<EF.Order, Order>().ReverseMap();

            CreateMap<EF.CartProduct, OrderItem>().ReverseMap();

            CreateMap<EF.OrderProduct, OrderItem>().ReverseMap();

            CreateMap<EF.Product, Product>().ReverseMap();

            CreateMap<EF.ProductDetails, ProductDetails>().ReverseMap();

            CreateMap<CartItem, EF.CartProduct>().ReverseMap();

        }
    }
}
