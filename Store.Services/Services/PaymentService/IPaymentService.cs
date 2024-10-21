using Store.Services.Services.BasketService.Dtos;
using Store.Services.Services.OrderService.Dtos;


namespace Store.Services.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<CustomerBasketDto> CreateOrUpdatePaymentIntent(CustomerBasketDto input);
        Task<OrderDetailsDto> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<OrderDetailsDto> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
