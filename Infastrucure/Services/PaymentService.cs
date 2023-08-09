using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
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
        public Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            throw new NotImplementedException();
        }
    }
}
