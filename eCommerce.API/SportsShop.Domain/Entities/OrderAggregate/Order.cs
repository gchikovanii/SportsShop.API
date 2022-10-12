using SportsShop.Domain.Constants;
using SportsShop.Domain.Entities.BaseEntity;
using SportsShop.Domain.Entities.ProductAggregate;
using SportsShop.Domain.Entities.UserAggregte;
using SportsShop.Domain.Entities.UserAggregte.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Domain.Entities.OrderAggregate
{
    public class Order : Entity
    {
        public string BuyerEmail { get; set; }
        public int BuyerId { get; set; }
        public AppUser Buyer { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

    }
}
