﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities.OrderEntities;


namespace Store.Services.Services.OrderService.Dtos
{
    public class OrderItemPictureUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductItem.PictureUrl) || source.ProductItem.PictureUrl.Contains(source.ProductItem.PictureUrl))
            {
                return $"{_configuration["BaseUrl"]}{source.ProductItem.PictureUrl}";
            }
            return null;
        }
    }
}
