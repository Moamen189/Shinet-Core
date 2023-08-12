using API.Errors;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Infastrucure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService paymentService;
        private readonly ILogger<PaymentController> _logger;
        private const string Whsecret = "whsec_1d2d4c462169bc9b7eed13dc8c581b1b3deec7b51d4473ff66b4d61d3e82d8e6";

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger1)
        {
            this.paymentService = paymentService;
            this._logger = logger1;
        }


        [Authorize]
        [HttpPost("{basketId}")]


        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {

            var basket = await paymentService.CreateOrUpdatePaymentIntent(basketId);

            if (basket == null)
            {
                return BadRequest(new ApiResponse(400, "Problem with your basket"));
            }

           return basket;


        }


        [HttpPost("webhook")]

        public async Task<ActionResult> StripeWebHook()
        {
            var json = await new  StreamReader(Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], Whsecret);
            PaymentIntent intent;

            Core.Entities.OrderAggregate.Order order;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment succeded", intent.Id);
                    order = await paymentService.UpdateOrderPaymentSuccedd(intent.Id);
                    _logger.LogInformation("order updated to Payment Succedd", order.Id);
                   
                    break;

                case "payment_intent.payment_failed":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment failed", intent.Id);
                    order = await paymentService.UpdateOrderPaymentFailed(intent.Id);
                    _logger.LogInformation("Order Updated to payment failed", order.Id);

                    break;

            }

            return new EmptyResult();


        }

    }
}
