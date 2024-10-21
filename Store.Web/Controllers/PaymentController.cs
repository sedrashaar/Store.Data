using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Services.BasketService.Dtos;
using Store.Services.Services.PaymentService;
using Store.Web.Controllers;
using Stripe;

namespace Store.API.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;
        const string endpointSecret = "whsec_14845bg94467dc1r8r8r550151563d9cc7c8eea184b026c4e25c5b6ff78e678f";
        public PaymentController( IPaymentService paymentService , ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrderUpdatePaymentIntent(CustomerBasketDto input)
         => Ok(await _paymentService.CreateOrUpdatePaymentIntent(input));

        [HttpPost]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeSignature = Request.Headers["Stripe-Signature"].FirstOrDefault();
            if (string.IsNullOrEmpty(stripeSignature))
            {
                return BadRequest("Missing Stripe-Signature header.");
            }

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                                   Request.Headers["Stripe-Signature"], endpointSecret);

                PaymentIntent paymentIntent;

                if (stripeEvent.Type == "payment_intent.succeeded")
                {
                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;

                    _logger.LogInformation("Payment succeeded :" , paymentIntent.Id);
                    var order = await _paymentService.UpdateOrderPaymentSucceeded(paymentIntent.Id);
                    _logger.LogInformation("Order Updated to payment succeeded :", order.Id);
                }
                else if (stripeEvent.Type == "payment_intent.payment_failed")
                {
                    paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                  
                    _logger.LogInformation("Payment failed:", paymentIntent.Id);
                    var order = await _paymentService.UpdateOrderPaymentFailed(paymentIntent.Id);
                    _logger.LogInformation("Order Updated to payment failed :", order.Id);
                }
                else if (stripeEvent.Type == "payment_intent.created")
                {
                    _logger.LogInformation("Payment created");
                }
                else
                {
                    Console.WriteLine("Unhandled event type : {0}",stripeEvent.Type);
                }

                return Ok(); 
            }
            catch (StripeException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
