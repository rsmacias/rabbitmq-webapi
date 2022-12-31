#nullable disable
using Microsoft.AspNetCore.Mvc;
using Producer.Data;
using Producer.Dtos;

namespace Producer.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase {

        private readonly IOrderDbContext _context;

        public OrdersController(IOrderDbContext context) {
            _context = context;
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

            return Ok(new { id = order.Id });
        }

    }

}