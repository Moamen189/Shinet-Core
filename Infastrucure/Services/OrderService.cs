using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IBasketRepository basket;

        public OrderService( IUnitOfWork unitOfWork ,IBasketRepository Basket )
        {
            this.unitOfWork = unitOfWork;
            basket = Basket;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket from basket repo 

            var baskett = await basket.GetBasketAsync(basketId);
            //get item from product repo 

            var items = new List<OrderItem>();

            foreach (var item in baskett.Items)
            {
                var productItem = await unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }


            //get delivery from  repo

            var deliveryMethodd = await unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            ////calc subtotal 
            ///
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var spec = new OrderByPaymentIntentIdSpecification(baskett.PaymentIntentId);

            var order = await unitOfWork.Repository<Order>().GetEntityWithSpec(spec);

            if(order!= null)
            {
                order.ShipToAddress= shippingAddress;
                order.DeliveryMethod = deliveryMethodd;
                order.Subtotal = subtotal;
                unitOfWork.Repository<Order>().Update(order);
            }else
            {
                order = new Order(buyerEmail, shippingAddress, deliveryMethodd, items, subtotal, baskett.PaymentIntentId);
                unitOfWork.Repository<Order>().Add(order);
            }
           ///create order 
          

            ///save to db   
            var result = await unitOfWork.Complete();
            //await basket.DeleteBasketAsync(basketId);

            if (result <= 0) return null;
            ///return order   
            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GeDeliveryMethodsForUserAsync()
        {
           return await unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
        }

        public async Task<Order> GetOrderbyIdAsync(int id, string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(id , buyerEmail);

            return await unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(buyerEmail);

            return await unitOfWork.Repository<Order>().GetListWithSpec(spec);
        }
    }
}
