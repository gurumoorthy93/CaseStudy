using CaseStudy.Core.Dtos;
using CaseStudy.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Input");

            var result = ordersService.GetOrderById(id, out OrderDto orderDto);

            if (result < 0)
            {
                switch (result)
                {
                    case -1:
                        return BadRequest("Invalid User Login");
                    case -2:
                        return BadRequest("Invalid Order Id");
                    case -3:
                        return BadRequest("Order is not placed by the Logged In User");
                }
            }

            return Ok(orderDto);
        }

        [HttpGet("search")]
        public IActionResult GetOrders([FromQuery] int PageNo, [FromQuery] int PageSize)
        {
            var result = ordersService.GetOrders(PageNo, PageSize, out OrderListDto orderList);

            if (result < 0)
                return BadRequest("Invalid User Login");

            return Ok(orderList);
        }

        [HttpPost()]
        public IActionResult PlaceOrder([FromBody] List<PlaceOrderDto> placeOrderDto)
        {
            if (placeOrderDto == null)
                return BadRequest("Invalid Input");

            var result = ordersService.PlaceOrder(placeOrderDto);

            if (result <= 0)
            {
                switch(result)
                {
                    case -1:
                        return BadRequest("Invalid User Login");
                    case -2:
                        return BadRequest("Requested product is Out of Stock");
                    case -3:
                        return BadRequest("Requested product Quantity is more than the available Stock");
                    case -4:
                        return BadRequest("Invalid Product");
                    default:
                        return BadRequest("Unknown Error");
                }
            }

            return Ok(new { OrderId = result });
        }
    }
}
