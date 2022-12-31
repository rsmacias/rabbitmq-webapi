#nullable disable
using Microsoft.AspNetCore.Mvc;
using Producer.Data;
using Producer.Dtos;
using Producer.RabbitMQ;

namespace Producer.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase {

        private readonly IOrderDbContext _context;
        private readonly IMessageProducer _ordersPublisher;

        public OrdersController(IOrderDbContext context, IMessageProducer ordersPublisher) {
            _context = context;
            _ordersPublisher = ordersPublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder (OrderDto orderDto) {
            Order order = new() {
                ProductName = orderDto.ProductName,
                Price = orderDto.Price,
                Quantity = orderDto.Quantity
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            _ordersPublisher.SendMessage(order);

            return Ok(new { id = order.Id });
        }

    }

}