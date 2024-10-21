using System.ComponentModel.DataAnnotations;

namespace Store.Services.Services.OrderService.Dtos
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public string BuyerEmail { get; set; }
        public AddressDto ShippingAddress { get; set; }
        [Required]
        public int DeliveryMethodId { get; set; }
    }
}
