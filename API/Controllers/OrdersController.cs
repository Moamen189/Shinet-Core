using API.Dtos;
using API.Errors;
using API.Extentions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using StackExchange.Redis;

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
            if (order == null) return BadRequest(new ApiResponse(400, "Problem Creating Order"));

            return Ok(order);
        }


        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUsers()
        {
            var email = HttpContext.User?.RetrieveEmailFromPrincipal();

            var orders = await _orderService.GetOrdersForUserAsync(email);

            return Ok(orders);

        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Order>> GetOrderByIdForUser(int id)
        {
            var email = HttpContext.User?.RetrieveEmailFromPrincipal();

            var Order = await _orderService.GetOrderbyIdAsync(id, email);
            if (Order == null) return NotFound(new ApiResponse(404));
            return Ok(Order);

        }

        [HttpGet("deliveryMethods")]

        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            return Ok(await _orderService.GeDeliveryMethodsForUserAsync());
        }


    }
}
