using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> order;
        private readonly IGenericRepository<Product> product;
        private readonly IGenericRepository<DeliveryMethod> DmRepo;
        private readonly IBasketRepository basket;

        public OrderService(IGenericRepository<Order> Order , IGenericRepository<Product> Product, IGenericRepository<DeliveryMethod> DeliveryMethod , IBasketRepository Basket )
        {
            order = Order;
            product = Product;
            DmRepo = DeliveryMethod;
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
                var productItem = await product.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }


            //get delivery from  repo

            var deliveryMethodd = await DmRepo.GetByIdAsync(deliveryMethodId);
            ////calc subtotal 
            ///
            var subtotal = items.Sum(item => item.Price * item.Quantity);
           ///create order 
           var order = new Order( buyerEmail , shippingAddress, deliveryMethodd, items, subtotal);
            ///save to db 
            ///return order   
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GeDeliveryMethodsForUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderbyIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
