using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specification;
using Infastrucure.Data;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IBasketRepository basketRepository;

        public PaymentService(IUnitOfWork unitOfWork , IConfiguration configuration  , IBasketRepository basketRepository)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.basketRepository = basketRepository;
        }
        public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = configuration["StripeSettings:SecretKey"];
            var basket = await basketRepository.GetBasketAsync(basketId);

            if (basket == null) return null;
            var shippingPrice =0m;

            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await unitOfWork.Repository<DeliveryMethod>().GetByIdAsync((int)basket.DeliveryMethodId);

                shippingPrice = deliveryMethod.Price;


            }


            foreach(var item in basket.Items)
            {
                var productItem = await unitOfWork.Repository<Core.Entities.Product>().GetByIdAsync(item.Id);
                if(item.Price != productItem.Price)
                {

                    item.Price = productItem.Price;
                }
            }


            var service = new PaymentIntentService();

            PaymentIntent intent;


            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) +
                             (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) +
                             (long)shippingPrice * 100
                };

                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await basketRepository.UpdateBasketAsync(basket);
            return basket;

        }

        public async Task<Core.Entities.OrderAggregate.Order> UpdateOrderPaymentFailed(string paymentIntentId)
        {
            var spec = new OrderByPaymentIntentIdSpecification(paymentIntentId);
            var order = await unitOfWork.Repository<Core.Entities.OrderAggregate.Order>().GetEntityWithSpec(spec);

            if (order == null) return null;
            order.Status = OrderStatus.PaymentFailed;
            await unitOfWork.Complete();

            return order;
        }

        public async Task<Core.Entities.OrderAggregate.Order> UpdateOrderPaymentSuccedd(string paymentIntentId)
        {
            var spec = new OrderByPaymentIntentIdSpecification(paymentIntentId);
            var order = await unitOfWork.Repository<Core.Entities.OrderAggregate.Order>().GetEntityWithSpec(spec);

            if (order == null) return null;
            order.Status = OrderStatus.PaymentReceived;
            await unitOfWork.Complete();

            return order;
        }
    }
}
