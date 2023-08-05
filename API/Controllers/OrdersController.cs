using API.Dtos;
using API.Extentions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService , IMapper mapper)
        {
            _orderService = orderService;
            this.mapper = mapper;
        }

        [HttpPost]

        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            //claims 
            var email = HttpContext.User?.RetrieveEmailFromPrincipal();

            var address = mapper.Map<AddressDto , Address>(orderDto.ShipToAddress);

            var order = _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId , orderDto.BasketId ,address);
        }
    }
}
