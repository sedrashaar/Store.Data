﻿using AutoMapper;
using Store.Data.Entities.OrderEntities;


namespace Store.Services.Services.OrderService.Dtos
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress , AddressDto>().ReverseMap();
            CreateMap<Order, OrderDetailsDto>()
               .ForMember(dest => dest.DeliveryMethodName, options => options.MapFrom(src => src.DeliveryMethods.ShortName))
               .ForMember(dest => dest.ShippingPrice, options => options.MapFrom(src => src.DeliveryMethods.Price));

            CreateMap<OrderItem, OrderItemDto>()
               .ForMember(dest => dest.ProductItemId, options => options.MapFrom(src => src.ProductItem.ProductId))
               .ForMember(dest => dest.ProductName, options => options.MapFrom(src => src.ProductItem.ProductName))
               .ForMember(dest => dest.PictureUrl, options => options.MapFrom(src => src.ProductItem.PictureUrl))
               .ForMember(dest => dest.PictureUrl, options => options.MapFrom<OrderItemPictureUrlResolver>()).ReverseMap();
        }
    }
}
 