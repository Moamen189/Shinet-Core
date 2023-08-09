using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
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
            
        }
    }
}
