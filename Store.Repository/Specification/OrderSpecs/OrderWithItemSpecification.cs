﻿
using Order = Store.Data.Entities.OrderEntities.Order;

namespace Store.Repository.Specification.OrderSpecs
{
    public class OrderWithItemSpecification : BaseSpecification<Order>
    {
        public OrderWithItemSpecification(string buyerEmail) 
            : base(order => order.BuyerEmail == buyerEmail)
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethods);
            AddOrderByDes(order => order.OrderDate);
        }

        public OrderWithItemSpecification(Guid id , string buyerEmail )
            : base(order => order.Id == id  && order.BuyerEmail == buyerEmail)
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethods);
        }

    }
}
